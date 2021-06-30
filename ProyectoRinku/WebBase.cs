using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProyectoRinku
{
    public class WebBase : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var current = HttpContext.Current;
            var session = current.Session;

            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            if ((HttpContext.Current == null || HttpContext.Current.Session == null || HttpContext.Current.Session[SessionAdmin.SessionName] == null) && Request.Url.AbsolutePath.ToUpper().IndexOf(FormsAuthentication.LoginUrl.ToUpper()) < 0)
            {
                FormsAuthentication.RedirectToLoginPage();
                Response.End();
            }
            else
            {
                var previousURL = Request.UrlReferrer;

                var previousUrlPage = string.Empty;

                var urls = Request.CurrentExecutionFilePath.Split('/');

                var currentUrl = urls[urls.Length - 1];

                previousUrlPage = FormsAuthentication.DefaultUrl;

                urls = FormsAuthentication.LoginUrl.Split('/');

                var urls2 = FormsAuthentication.DefaultUrl.Split('/');

              /*  if (currentUrl.ToUpper() != urls[urls.Length - 1].ToUpper() && currentUrl.ToUpper() != urls2[urls2.Length - 1].ToUpper() && !(new BLL.UsuariosPermisos().ObtenerPermiso(currentUrl, HttpContext.Current.Session[SessionAdmin.SessionName].ToString())))
                {
                    Response.Redirect(previousUrlPage, true);
                }*/
            }
        }
    }
}