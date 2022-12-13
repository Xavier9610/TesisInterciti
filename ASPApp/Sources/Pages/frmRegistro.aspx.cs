using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPApp.Sources.Validaciones;
using ASPApp.ServiceReferenceInterciti;
namespace ASPApp.Sources.Pages
{
    public partial class frmRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Registrarme_Click(object sender, EventArgs e)
        {
          //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + (dateB.Value.Split('-')[0])+(dateB.Value.Split('-')[1])+ (dateB.Value.Split('-')[2]) + "" + "')", true);
            if (txtApellido != null && txtCedula != null && txtCorreo != null && txtNombre != null && txtPass!=null && txtPassC!=null && txtTelefono!=null && fotoUsuario!=null) 
            {
                if (txtApellido.Text != "" && txtCedula.Text != "" && txtCorreo.Text != "" && txtNombre.Text != "" && txtPass.Text != "" && txtPassC.Text != "" && txtTelefono.Text != "" && dateB.Value != "")
                {
                    if (txtPass.Text == txtPassC.Text)
                    {
                        if (Validaciones.Validaciones.ValidarTelefonos10Digitos(txtTelefono.Text))
                        {
                            //
                            if (Validaciones.Validaciones.VerificaIdentificacion(txtCedula.Text))
                            {
                                //
                                if (txtPass.Text.Length > 7)
                                {
                                    //
                                    ServiceClient client = new ServiceClient("BasicHttpsBinding_IService", "https://wcfserviceappinterciti.azurewebsites.net/Service.svc");
                                    if (client.AgregarAdmin(txtNombre.Text,client.sha256_hash(txtPass.Text),txtApellido.Text,txtCedula.Text,txtCorreo.Text,txtTelefono.Text,new DateTime(Convert.ToInt32(dateB.Value.Split('-')[0]), Convert.ToInt32(dateB.Value.Split('-')[1]), Convert.ToInt32(dateB.Value.Split('-')[2])),false,"",Servicio.Compress(( FUImage.FileBytes)) )==0)
                                     {
                                        //exitoso
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                        Response.Redirect("/Sources/Pages/frmIndex.aspx");
                                    }
                                     else
                                     {
                                        //no registrado
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                                    }
                                    
                                }
                                else
                                {
                                    //contrsena debil
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La contraseña debe tener almenos 8 caracteres')", true);
                                }
                            }
                            else
                            {
                                //
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cedula no valida')", true);
                            }
                        }
                        else
                        {
                            //telefono mal
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Telefono erroneo')", true);
                        }
                    }
                    else
                    {
                        //pass mal
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Las contraseñas no coiciden')", true);
                    }
                }
                else
                {
                    //datos mal
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
                }        
            }
            else
            {
                //datos mal
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmLogin.aspx");
        }
    }
}