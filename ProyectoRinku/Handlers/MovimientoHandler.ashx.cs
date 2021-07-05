using BLL;
using Entities.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProyectoRinku.Handlers
{
    /// <summary>
    /// Summary description for EmpleadoHandler
    /// </summary>
    public class MovimientoHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var method = context.Request["method"];
            if (method == "ObtenerMovimiento")
            {
                ObtenerMovimiento(context);
            }
            if (method == "ObtenerMovimientos")
            {
                ObtenerMovimientos(context);
            }
            if (method == "ObtenerSueldoMensual")
            {
                ObtenerSueldoMensual(context);
            }
        }
        private void ObtenerMovimiento(HttpContext context)
        {
            var request = context.Request;
            int codigo = 0;
            int.TryParse(request["args[codigo]"], out codigo);

            var classMovimientos = new Movimientos();
            
            var item = classMovimientos.obtenerPorCodigo(codigo, x =>
               new MovimientoDTO
               {
                   Codigo = x.Codigo,
                   NumeroEmpleado = x.NumeroEmpleado,
                   Fecha = x.Fecha,
                   CubrioTurno = x.CubrioTurno,
                   CantidadEntregas = x.CantidadEntregas,
                   RolCubrio = x.RolCubrio
               });

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(
                new
                {
                    item.Codigo,
                    item.NumeroEmpleado,
                    Fecha= item.Fecha.ToString("yyyy-MM-dd"),
                    item.CubrioTurno,
                    item.CantidadEntregas,
                    item.RolCubrio
                }
                ));
        }

        private void ObtenerMovimientos(HttpContext context)
        {
            var classMovimientos = new Movimientos();

            var Movimientos = classMovimientos.Filter(x => new MovimientoDTO
            {
                Codigo = x.Codigo,
                NumeroEmpleado = x.NumeroEmpleado,
                Fecha = x.Fecha,
                CubrioTurno = x.CubrioTurno,
                CantidadEntregas = x.CantidadEntregas
            });

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(new
            {
                Movimientos = Movimientos.Select(x=> new
                {
                    x.Codigo,
                    x.NumeroEmpleado,
                    Fecha = x.Fecha.ToString("dd-MM-yyyy"),
                    CubrioTurno= x.CubrioTurno?"Si":"No",
                    x.CantidadEntregas
                })
            }));
        }

        private void ObtenerSueldoMensual(HttpContext context)
        {
            var request = context.Request;
            int numeroempleado = 0;
            int.TryParse(request["args[numeroempleado]"], out numeroempleado);
            var fecha = request["args[fecha]"].Split('-');
            var año = Convert.ToInt32(fecha[0]);
            var mes = Convert.ToInt32(fecha[1]);
            var classMovimientos = new Movimientos();
            var classEmpleados = new Empleados();

            var Empleado = classEmpleados.obtenerPorNumero(numeroempleado, x => new EmpleadoDTO { Rol = x.Rol, Tipo = x.Tipo,PorcValeDespensa = x.CatalogoTipoEmpleado.DespensaPorc, ExtraPorEntregas = x.CatalogoRol.ExtraPorEntrega, HorasRol = x.CatalogoRol.Horas, BaseRol = x.CatalogoRol.SueldoBase, BonoRol = x.CatalogoRol.Bono });
            var Impuesto = classMovimientos.obtenerISR(x => new CatalogoImpuestoDTO { ISRNormal = x.ISRNormal, ISRExtra = x.ISRExtra, TopeSalario = x.TopeSalario });
            var sueldoBase = 0;
            var totalEntregas = 0;
            var bonoPorHoras = 0;
            double ISR = 0;
            double valesDespensa = 0;
            double sueldoNeto = 0;
            var Movimientos = classMovimientos.Filter(x => new MovimientoDTO
            {
                Codigo = x.Codigo,
                NumeroEmpleado = x.NumeroEmpleado,
                Fecha = x.Fecha,
                CubrioTurno = x.CubrioTurno,
                CantidadEntregas = x.CantidadEntregas,
                RolCubrio = x.RolCubrio
            }).Where(x=> x.Fecha.Month == mes && x.Fecha.Year == año);

            foreach (var movimiento in Movimientos)
            {
                totalEntregas += movimiento.CantidadEntregas;
                if (movimiento.CubrioTurno)
                {
                    var rolBono = classEmpleados.obtenerRolPorCodigo(movimiento.RolCubrio, x => new CatalogoRolDTO { Bono = x.Bono }).Bono;
                    bonoPorHoras += Empleado.HorasRol * rolBono;
                }else
                {
                    bonoPorHoras += Empleado.HorasRol * Empleado.BonoRol;
                }
            }

            sueldoBase = (Empleado.BaseRol * Empleado.HorasRol) * Movimientos.Count();
            var extraEntregas = totalEntregas * Empleado.ExtraPorEntregas;

            double sueldoTotal = sueldoBase + extraEntregas + bonoPorHoras;
            if(sueldoTotal> Impuesto.TopeSalario)
            {
                ISR = (sueldoTotal * ((double)Impuesto.ISRExtra / 100));
            }else
            {
                ISR = (sueldoTotal * ((double)Impuesto.ISRNormal/100));
            }

            valesDespensa = sueldoTotal * ((double)Empleado.PorcValeDespensa / 100);

            sueldoNeto = (sueldoTotal + valesDespensa) - (ISR);

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(new
            {
                totalEntregas,
                sueldoBase,
                extraEntregas,
                bonoPorHoras,
                ISR,
                valesDespensa,
                sueldoNeto,
                diasTrabajados = Movimientos.Count()

            }));
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}