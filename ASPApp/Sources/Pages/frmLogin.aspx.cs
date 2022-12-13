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
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            
            if (txtUsuario != null && txtPass != null)
            {
                if (txtUsuario.Text != "" && txtPass.Text != "")
                {
                    Admin auth = null;
                    if (txtUsuario.Text.Contains("@"))
                    {
                        if (Validaciones.Validaciones. EsCorreoValido(txtUsuario.Text))
                        {
                            auth = Servicio.GetLoginCorreo(txtUsuario.Text, txtPass.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario o contrasena incorrecta')", true);
                            Session["usuarioId"] = null;
                        }

                    }
                    else
                    {
                        if (Validaciones.Validaciones.VerificaIdentificacion(txtUsuario.Text))
                        {

                            auth = Servicio.GetLoginCI(txtUsuario.Text, txtPass.Text);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario o contrasena incorrecta')", true);
                            Session["usuarioId"] = null;
                        }

                    }
                    if (auth != null)
                    {
                        Session["usuarioId"] = auth.IdAdmin;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Login exitoso')", true);
                        Response.Redirect("/Sources/Pages/frmIndex.aspx");
                        
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
                    Session["usuarioId"] = null;
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
                Session["usuarioId"] = null;
            }
            
        }
    }
}