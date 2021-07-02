using BLL;
using Entities.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRinku
{
    public partial class EmpleadosEdit : WebBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Guardar(EmpleadoDTO item)
        {
            var classEmpleado = new Empleados();

            var message = "";

            try
            {
                classEmpleado.Guardar(item);
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error, intente de nuevo";
            }

            return JsonConvert.SerializeObject(message);
        }

        [WebMethod]
        public static string Eliminar(int numEmpleado)
        {
            var classEmpleado = new Empleados();

            var message = "";

            try
            {
                classEmpleado.Eliminar(numEmpleado);
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error, intente de nuevo";
            }

            return JsonConvert.SerializeObject(message);
        }
    }
}