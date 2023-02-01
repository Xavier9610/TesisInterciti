using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPApp.ServiceReferenceInterciti;
using ASPApp.Sources.Validaciones;

namespace ASPApp.Sources.Pages
{
    public partial class MPInterciti : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioId"]!=null)
            {
                ServiceClient client = new ServiceClient("BasicHttpBinding_IService", "https://wcfappservice.azurewebsites.net/Service.svc");
                var user = client.FindAdminByID(Convert.ToInt32(Session["usuarioId"].ToString()));
                imgPerfil.ImageUrl = "data:image;base64," + Convert.ToBase64String(Servicio.Decompress( user.Picture));
                lblUsuario.Text = user.Nombre + " " + user.Apellido;
            }
            else
            {
                Response.Redirect("/Sources/Pages/frmLogin.aspx");
            }
        }
        protected void GoPerfil(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmPerfil.aspx");
        }
        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session["usuarioId"] = null;
            Response.Redirect("/Sources/Pages/frmLogin.aspx");
        }

    }
}