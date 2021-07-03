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
    public partial class MovimientosEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Guardar(MovimientoDTO item)
        {
            var classMovimientos = new Movimientos();

            var message = "";

            try
            {
                classMovimientos.Guardar(item);
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error, intente de nuevo";
            }

            return JsonConvert.SerializeObject(message);
        }

        [WebMethod]
        public static string Eliminar(int codigo)
        {
            var classMovimientos = new Movimientos();

            var message = "";

            try
            {
                classMovimientos.Eliminar(codigo);
            }
            catch (Exception ex)
            {
                message = "Ocurrió un error, intente de nuevo";
            }

            return JsonConvert.SerializeObject(message);
        }
    }
}