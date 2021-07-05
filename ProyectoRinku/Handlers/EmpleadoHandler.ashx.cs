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
    public class EmpleadoHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var method = context.Request["method"];
            if (method == "ObtenerEmpleado")
            {
                ObtenerEmpleado(context);
            }
            if (method == "ObtenerEmpleados")
            {
                ObtenerEmpleados(context);
            }
            if (method == "ObtenerComboEmpleados")
            {
                ObtenerComboEmpleados(context);
            }
            if(method== "ObtenerRolEmpleado")
            {
                ObtenerRolEmpleado(context);
            }
        }
        private void ObtenerEmpleado(HttpContext context)
        {
            var request = context.Request;
            int numero = 0;
            int.TryParse(request["args[numero]"], out numero);

            if (numero == 0)
            {
                context.Response.ContentType = "application/json";
                context.Response.Write(JsonConvert.SerializeObject(""));
                return;
            }else
            {
                var classEmpleados = new Empleados();

                var item = classEmpleados.obtenerPorNumero(numero, x =>
                   new EmpleadoDTO
                   {
                       Numero = x.Numero,
                       Nombre = x.Nombre,
                       ApellidoPaterno = x.ApellidoPaterno,
                       ApellidoMaterno = x.ApellidoMaterno,
                       Rol = x.Rol,
                       Tipo = x.Tipo,
                       PuedeCubrir = x.CatalogoRol.PuedeCubrir
                   });

                context.Response.ContentType = "application/json";
                context.Response.Write(JsonConvert.SerializeObject(
                    new
                    {
                        item.Numero,
                        item.Nombre,
                        item.ApellidoPaterno,
                        item.ApellidoMaterno,
                        item.Rol,
                        item.Tipo,
                        item.PuedeCubrir
                    }
                    ));
            }

        }

        private void ObtenerEmpleados(HttpContext context)
        {
            var classEmpleados = new Empleados();

            var Empleados = classEmpleados.Filter(x => new EmpleadoDTO {
                Numero = x.Numero,
                Nombre = x.Nombre,
                ApellidoPaterno =x.ApellidoPaterno,
                ApellidoMaterno = x.ApellidoMaterno,
                Tipo = x.Tipo,
                NombreTipo = x.Tipo==1?"Interno":"Externo",
                NombreRol =x.CatalogoRol.Descripcion });

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(new
            {
                Empleados
            }));
        }

        private void ObtenerComboEmpleados(HttpContext context)
        {
            var classEmpleados = new Empleados();

            var Empleados = classEmpleados.Filter(x => new EmpleadoDTO
            {
                Numero = x.Numero,
                Nombre = x.Nombre,
                ApellidoPaterno = x.ApellidoPaterno,
                ApellidoMaterno = x.ApellidoMaterno,
                Tipo = x.Tipo,
                NombreTipo = x.Tipo == 1 ? "Interno" : "Externo",
                NombreRol = x.CatalogoRol.Descripcion,
                Rol = x.Rol
            });

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(new
            {
                Combo = Empleados.Select(x=> new
                {
                    Codigo= x.Numero,
                    Nombre = x.Numero+" - "+x.Nombre+" "+x.ApellidoPaterno+" "+x.ApellidoMaterno
                })
            }));
        }
        private void ObtenerRolEmpleado(HttpContext context)
        {
            var request = context.Request;
            int numero = 0;
            int.TryParse(request["args[numero]"], out numero);
            var classEmpleados = new Empleados();

            var Empleados = classEmpleados.Filter(x => new EmpleadoDTO
            {
                Numero = x.Numero,
                Nombre = x.Nombre,
                ApellidoPaterno = x.ApellidoPaterno,
                ApellidoMaterno = x.ApellidoMaterno,
                Tipo = x.Tipo,
                NombreTipo = x.Tipo == 1 ? "Interno" : "Externo",
                NombreRol = x.CatalogoRol.Descripcion,
                Rol = x.Rol
            });

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(new
            {
                Combo = Empleados.Select(x => new
                {
                    Codigo = x.Numero,
                    Nombre = x.Numero + " - " + x.Nombre + " " + x.ApellidoPaterno + " " + x.ApellidoMaterno
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