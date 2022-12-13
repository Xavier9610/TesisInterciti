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
    public partial class frmVehiculoCRUD : System.Web.UI.Page
    {
        private Vehiculo cliente;
        private ServiceClient client = new ServiceClient("BasicHttpsBinding_IService", "https://wcfserviceappinterciti.azurewebsites.net/Service.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                  //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Request.QueryString["id"].ToString() + "')", true);
                    cliente = client.FindVehiculoByID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                }
                if (Request.QueryString["op"] != null)
                {
                    var op = Request.QueryString["op"];
                    switch (op)
                    {
                        case "C":
                            ActivarControles();
                            lblTitulo.Text = "Nuevo Vehiculo";
                            btnRegistrar.Text = "Nuevo";
                            break;
                        case "R":
                            DesactivarControles();
                            LlenarDatos();
                            lblTitulo.Text = "Mostrar Vehiculo";

                            break;
                        case "U":
                            ActivarControles();
                            LlenarDatos();
                            lblTitulo.Text = "Actualizar Vehiculo";
                            btnRegistrar.Text = "Guardar Cambios";
                            break;
                    }
                }
            }
        }

        private void DesactivarControles()
        {
            btnRegistrar.Visible = false;
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtPlaca.Enabled = false;
            txtTipo.Enabled = false;
            anio.Enabled = false;
        }

        private void ActivarControles()
        {
            btnRegistrar.Visible = true;
            txtMarca.Enabled = true;
            txtModelo.Enabled = true;
            txtPlaca.Enabled = true;
            txtTipo.Enabled = true;
            anio.Enabled = true;
        }

        private void LlenarDatos()
        {
            txtMarca.SelectedValue = client.FindModeloVehiculoByModelo(cliente.Modelo1).IdMarca.ToString();
            txtModelo.SelectedValue = client.FindModeloVehiculoByModelo(cliente.Modelo1).IdModelo.ToString();
            txtPlaca.Text = cliente.Placa;
            txtTipo.SelectedValue = client.FindTipoVehiculoByTipo(cliente.Tipo1).ToString();
            anio.SelectedValue = client.FindAñoVehiculoByIdAño(cliente.Año1).IdAño.ToString();
            fotoUsuario.Src = "data:image;base64," + Convert.ToBase64String(Servicio.Decompress(cliente.Picture));
           
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtMarca != null && txtModelo != null && txtPlaca != null && txtTipo != null && anio != null && fotoUsuario != null)
            {
                if (txtMarca.SelectedItem != null && txtModelo.SelectedItem != null && txtPlaca.Text != "" && txtTipo.SelectedItem != null && anio.SelectedItem != null )
                {
                    switch (lblTitulo.Text)
                    {
                        case "Nuevo Vehiculo":
                            var aux = Servicio.client.GenerarPass();
                            if (Servicio.client.AgregarVehiculo(txtPlaca.Text,Convert.ToInt32( txtTipo.SelectedValue), Convert.ToInt32(txtModelo.SelectedValue), Convert.ToInt32(anio.SelectedValue), Convert.ToInt32(txtMarca.SelectedValue),Servicio.Compress(FUImage.FileBytes)) == 0)
                            {
                                //exitoso
                                 Response.Redirect("/Sources/Pages/frmVehiculo.aspx");
                            }
                            else
                            {
                                //no registrado
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
                        case "Actualizar Vehiculo":
                            cliente = client.FindVehiculoByID(Convert.ToInt32(Request.QueryString["id"].ToString()));
                            if (FUImage.FileName != "")
                            {
                                cliente.Picture = Servicio.Compress( FUImage.FileBytes);
                            }
                            cliente.Año1 = client.FindAñoVehiculoById(Convert.ToInt32(anio.Text)).Año;
                            cliente.Modelo1 = client.FindModeloVehiculoById(Convert.ToInt32(txtModelo.Text)).Modelo;
                            cliente.Placa = txtPlaca.Text;
                            cliente.Tipo1 = client.FindTipoVehiculoById(Convert.ToInt32(txtTipo.Text)).Tipo;
                            if (Servicio.client.ActualizarVehiculo(cliente) == 0)
                            {
                                //exitoso
                                //           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                Response.Redirect("/Sources/Pages/frmVehiculo.aspx");
                            }
                            else
                            {
                                //no registrado
                                lblInfo.Text = "Registro erroneo.";
                            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
                    }
                }
                else
                {
                    lblInfo.Text = "Datos vacios.";
                    //datos mal
                    //     ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
                }
            }
            else
            {
                lblInfo.Text = "Datos vacios.";
                //datos mal
               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
            }


        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmVehiculo.aspx");
        }
    }
}