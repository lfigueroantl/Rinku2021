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
                   CantidadEntregas = x.CantidadEntregas
               });

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(
                new
                {
                    item.Codigo,
                    item.NumeroEmpleado,
                    Fecha= item.Fecha.ToString("yyyy-MM-dd"),
                    item.CubrioTurno,
                    item.CantidadEntregas
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}