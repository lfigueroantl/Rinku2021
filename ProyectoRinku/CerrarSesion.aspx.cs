using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRinku
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CloseSession();
        }

        [WebMethod]
        public static void CloseSession()
        {
            var current = HttpContext.Current;

            var session = current.Session;

            if (session[SessionAdmin.SessionName] != null)
            {
                session.Abandon();
                session.Clear();

                current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            }

            FormsAuthentication.SignOut();
            current.Response.Redirect(FormsAuthentication.LoginUrl);
            current.Response.End();
        }
    }
}