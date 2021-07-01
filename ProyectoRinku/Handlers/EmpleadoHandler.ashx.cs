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
        }
        private void ObtenerEmpleado(HttpContext context)
        {
            var request = context.Request;
            int numero = 0;
            int.TryParse(request["args[numero]"], out numero);

            var classEmpleados = new Empleados();

            var item = classEmpleados.obtenerPorNumero(numero, x =>
               new EmpleadoDTO
               {
                   Numero = x.Numero,
                   Nombre = x.Nombre,
                   ApellidoPaterno = x.ApellidoPaterno,
                   ApellidoMaterno = x.ApellidoMaterno,
                   Rol = x.Rol,
                   Tipo = x.Tipo
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
                    item.Tipo
                }
                ));
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
                NombreRol =x.CatalogoRol.Descripcion });

            context.Response.ContentType = "application/json";
            context.Response.Write(JsonConvert.SerializeObject(new
            {
                Empleados
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