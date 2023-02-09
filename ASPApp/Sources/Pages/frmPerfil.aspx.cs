using ASPApp.ServiceReferenceInterciti;
using ASPApp.Sources.Validaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPApp.Sources.Pages
{
    public partial class frmPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceClient client = new ServiceClient("BasicHttpBinding_IService", "https://wcfappservice.azurewebsites.net/Service.svc");
            var user = client.FindAdminByID(Convert.ToInt32(Session["usuarioId"].ToString()));
            txtNombre.Value = user.Nombre;
            txtApellido.Value = user.Apellido;
            txtCedula.Value = user.Cedula;
            txtCorreo.Value = user.Correo;
            txtTelefono.Value= user.Telefono;
            fotoUsuario.Src = "data:image;base64," + Convert.ToBase64String(Servicio.Decompress(user.Picture));
            dateB.Value = user.FechaNacimiento.Date.ToString();
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {

        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {

        }
        protected void Cambiar_Click(object sender, EventArgs e)
        {

        }
    }
}