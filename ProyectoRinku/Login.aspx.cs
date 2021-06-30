using BLL;
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
    public partial class Login : System.Web.UI.Page
    {
        public static object JsonConvert { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var session = HttpContext.Current.Session;

            if ((session != null) && (session[SessionAdmin.SessionName] != null))
            {
                Response.Redirect("default.aspx", true);
            }
        }

        [WebMethod]
        public static string ValidarUsuario(string usuario, string password)
        {
            var ususario = new Usuarios();
            var datosConsulta = new Datos();

            datosConsulta.Success = false;

            if (ususario.UserNamePassExist(usuario, password))
            {
                HttpContext.Current.Session[SessionAdmin.SessionName] = usuario;

                datosConsulta.Success = true;

                datosConsulta.Url = "default.aspx";
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(datosConsulta);
        }
    }
    class Datos
    {
        public bool Success { get; set; }
        public string Url { get; set; }
    }
}