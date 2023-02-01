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
    public partial class frmAdminCRUD : System.Web.UI.Page
    {
        private Admin cliente;
        private ServiceClient client = new ServiceClient("BasicHttpBinding_IService", "https://wcfappservice.azurewebsites.net/Service.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Request.QueryString["id"].ToString() + "')", true);
                    cliente = client.FindAdminByID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                    Session["aux"] = cliente.IdAdmin;
                }
                if (Request.QueryString["op"] != null)
                {
                    var op = Request.QueryString["op"];
                    switch (op)
                    {
                        case "C":
                            ActivarControles();
                            lblTitulo.Text = "Nuevo Administrador";
                            btnRegistrar.Text = "Nuevo";
                            break;
                        case "R":
                            DesactivarControles();
                            LlenarDatos();
                            lblTitulo.Text = "Mostrar Administrador";

                            break;
                        case "U":
                            ActivarControles();
                            LlenarDatos();
                            lblTitulo.Text = "Actualizar Administrador";
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
            estado.Visible = false;
        }

        private void ActivarControles()
        {
            txtApellido.Enabled = true;
            txtCedula.Enabled = true;
            txtCorreo.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            btnRegistrar.Visible = true;
            estado.Visible = true;
        }

        private void LlenarDatos()
        {
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtCedula.Text = cliente.Cedula;
            txtCorreo.Text = cliente.Correo;
            txtTelefono.Text = cliente.Telefono;
            fotoUsuario.Src = "data:image;base64," + Convert.ToBase64String(Servicio.Decompress(cliente.Picture));
            estado.Checked = cliente.Estado;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtApellido != null && txtCedula != null && txtCorreo != null && txtNombre != null && txtTelefono != null && FUImage.FileBytes != null)
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
                                case "Nuevo Administrador":
                                    var aux = Servicio.client.GenerarPass();
                                    if (Servicio.client.AgregarAdmin(txtNombre.Text, Servicio.client.sha256_hash(aux),txtApellido.Text, txtCedula.Text, txtCorreo.Text, txtTelefono.Text, new DateTime(Convert.ToInt32(dateB.Value.Split('-')[0]), Convert.ToInt32(dateB.Value.Split('-')[1]), Convert.ToInt32(dateB.Value.Split('-')[2])), false, "", Servicio.Compress((FUImage.FileBytes))) == 0)
                                    {
                                        //exitoso
                                        Servicio.client.SenMail(txtCorreo.Text, "Gracias por registrarte en Interciti S.A.", "Hola " + txtNombre.Text + Environment.NewLine + "Te recomendamos cambiar tu contraseña" + txtNombre.Text + Environment.NewLine + "Contraseña: " + aux);
                                        //         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                        Response.Redirect("/Sources/Pages/frmAdmin.aspx");
                                    }
                                    else
                                    {
                                        lblInfo.Text = "Error de Registro.";
                                        //no registrado
                           //             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                                    }
                                    break;
                                case "Actualizar Administrador":
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Actualizando')", true);
                                    cliente = client.FindAdminByID(Convert.ToInt32(Session["aux"]));
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
                                    cliente.Estado = estado.Checked;
                                    if (Servicio.client.ActualizarAdmin(cliente) == 0)
                                    {
                                        //exitoso
                                        //           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                        Response.Redirect("/Sources/Pages/frmAdmin.aspx?");
                                    }
                                    else
                                    {
                                        lblInfo.Text = "Error de Registro.";
                                        //no registrado
                                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                                    }
                                    break;
                            }

                        }
                        else
                        {
                            //
                            lblInfo.Text = "Cédula no valida.";
                       //     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cédula no valida')", true);
                        }
                    }
                    else
                    {
                        //telefono mal
                        lblInfo.Text = "Teléfono erroneo.";
                        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Telefono erroneo')", true);
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
            Response.Redirect("/Sources/Pages/frmAdmin.aspx");
        }
    }
}