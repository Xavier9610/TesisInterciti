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
    public partial class frmClienteCRUD : System.Web.UI.Page
    {
        private Cliente cliente;
        private ServiceClient client = new ServiceClient("BasicHttpsBinding_IService", "https://wcfserviceappinterciti.azurewebsites.net/Service.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                 //   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ Request.QueryString["id"].ToString() + "')", true);
                    cliente = client.FindClienteByID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                }
                if (Request.QueryString["op"] != null)
                {
                    var op = Request.QueryString["op"];
                    switch (op)
                    {
                        case "C":
                            ActivarControles();
                            lblTitulo.Text = "Nuevo usuario";
                            btnRegistrar.Text = "Nuevo";
                            break;
                        case "R":
                            DesactivarControles();
                            LlenarDatos();
                            lblTitulo.Text = "Mostrar usuario";
                            
                            break;
                        case "U":
                            ActivarControles();
                            LlenarDatos();
                            lblTitulo.Text = "Actualizar usuario";
                            btnRegistrar.Text = "Guardar Cambios";
                            break;
                    }
                }
            }
        }

        private void DesactivarControles()
        {
            txtApellido.Enabled = false;
            txtCedula.Enabled = false;
            txtCorreo.Enabled = false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            btnRegistrar.Visible = false;
        }

        private void ActivarControles()
        {
            txtApellido.Enabled = true;
            txtCedula.Enabled = true;
            txtCorreo.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            btnRegistrar.Visible = true;
        }

        private void LlenarDatos()
        {
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtCedula.Text = cliente.Cedula;
            txtCorreo.Text = cliente.Correo;
            txtTelefono.Text = cliente.Telefono;
            fotoUsuario.Src = "data:image;base64," + Convert.ToBase64String(Servicio.Decompress(cliente.Picture));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtApellido != null && txtCedula != null && txtCorreo != null && txtNombre != null &&  txtTelefono != null && fotoUsuario!=null)
            {
                if (txtApellido.Text != "" && txtCedula.Text != "" && txtCorreo.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "" && dateB.Value != "")
                {
                    if (Validaciones.Validaciones.ValidarTelefonos10Digitos(txtTelefono.Text))
                    {
                        //
                        if (Validaciones.Validaciones.VerificaIdentificacion(txtCedula.Text))
                        {
                            switch (lblTitulo.Text)
                            {
                                case "Nuevo usuario":
                                    var aux = Servicio.client.GenerarPass();
                                     if (Servicio. client.AgregarCliente(txtNombre.Text, Servicio.client.sha256_hash(aux), txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtTelefono.Text, new DateTime(Convert.ToInt32(dateB.Value.Split('-')[0]), Convert.ToInt32(dateB.Value.Split('-')[1]), Convert.ToInt32(dateB.Value.Split('-')[2])), "", Servicio.Compress((FUImage.FileBytes))) == 0)
                                    {
                                        //exitoso
                                        Servicio.client.SenMail(txtCorreo.Text, "Gracias por registrarte en Interciti S.A.", "Hola " + txtNombre.Text + Environment.NewLine + "Te recomendamos cambiar tu contraseña" + txtNombre.Text + Environment.NewLine + "Contraseña: " + aux);
                               //         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                        Response.Redirect("/Sources/Pages/frmCliente.aspx");
                                    }
                                    else
                                    {
                                        lblInfo.Text = "Error de registro.";
                                        //no registrado
                                        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                                    }
                                    break;
                                case "Actualizar usuario":
                                    cliente = client.FindClienteByID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                                    if (FUImage.FileName != "")
                                    {
                                        cliente.Picture = Servicio.Compress(FUImage.FileBytes);
                                    }
                                    cliente.Nombre = txtNombre.Text;
                                    cliente.Apellido = txtApellido.Text;
                                    cliente.Correo = txtCorreo.Text;
                                    cliente.Telefono = txtTelefono.Text;
                                    cliente.Cedula = txtCedula.Text;
                                    cliente.FechaNacimiento = new DateTime(Convert.ToInt32(dateB.Value.Split('-')[0]), Convert.ToInt32(dateB.Value.Split('-')[1]), Convert.ToInt32(dateB.Value.Split('-')[2]));
                                    
                                    if (Servicio. client.ActualizarCliente(cliente) == 0)
                                    {
                                        //exitoso
                             //           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                        Response.Redirect("/Sources/Pages/frmCliente.aspx");
                                    }
                                    else
                                    {
                                        lblInfo.Text = "Error de registro.";
                                        //no registrado
                                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                                    }
                                    break;
                            }
                            
                        }
                        else
                        {
                            lblInfo.Text = "Cédula no valida.";
                            //
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cedula no valida')", true);
                        }
                    }
                    else
                    {
                        lblInfo.Text = "Teléfono erroneo.";
                        //telefono mal
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Telefono erroneo')", true);
                    }
                }
                else
                {
                    lblInfo.Text = "Datos vacios.";
                    //datos mal
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
                }
            }
            else
            {
                lblInfo.Text = "Datos vacios.";
                //datos mal
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
            }
            

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmCliente.aspx");
        }
    }
}