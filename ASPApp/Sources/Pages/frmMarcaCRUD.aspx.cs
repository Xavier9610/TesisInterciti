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
    public partial class frmMarcaCRUD : System.Web.UI.Page
    {
        private MarcaVehiculo marca;
        private ServiceClient client = new ServiceClient("BasicHttpBinding_IService", "https://wcfappservice.azurewebsites.net/Service.svc");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
              //      ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Request.QueryString["id"].ToString() + "')", true);
                    marca = client.FindMarcaVehiculoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                }
                if (Request.QueryString["op"] != null)
                {
                    var op = Request.QueryString["op"];
                    switch (op)
                    {
                        case "C":
                            txtTipo.Enabled = true;
                            lblTitulo.Text = "Nuevo Marca";
                            btnRegistrar.Text = "Nuevo";
                            btnRegistrar.Visible = true;
                            btnRegistrar.Enabled = true;
                            break;
                        case "R":
                            txtTipo.Enabled = false;
                            btnRegistrar.Visible = false;
                            btnRegistrar.Enabled = false;
                            txtTipo.Text = marca.Marca;
                            lblTitulo.Text = "Mostrar Marca";

                            break;
                        case "U":
                            txtTipo.Enabled = true;
                            btnRegistrar.Visible = true;
                            btnRegistrar.Enabled = true;
                            txtTipo.Text = marca.Marca;
                            lblTitulo.Text = "Actualizar Marca";
                            btnRegistrar.Text = "Guardar Cambios";
                            break;
                    }
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtTipo != null)
            {
                if (txtTipo.Text != "")
                {
                    switch (lblTitulo.Text)
                    {
                        case "Nuevo Marca":
                            var aux = Servicio.client.GenerarPass();
                            if (Servicio.client.AgregarMarcaVehiculo(txtTipo.Text) == 0)
                            {
                                Response.Redirect("/Sources/Pages/frmMarca.aspx");
                            }
                            else
                            {
                                //no registrado
                                lblInfo.Text = "Registro erroneo.";
                      //          ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
                        case "Actualizar Marca":
                            marca = client.FindMarcaVehiculoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                            marca.Marca= txtTipo.Text;

                            if (Servicio.client.ActualizarMarca(marca) == 0)
                            {
                                //exitoso
                                //           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                Response.Redirect("/Sources/Pages/frmMarca.aspx");
                            }
                            else
                            {
                                lblInfo.Text = "Registro erroneo.";
                                //no registrado
                             //   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
                    }
                }
                else
                {
                    lblInfo.Text = "Datos vacios.";
                    //datos mal
                    //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
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
            Response.Redirect("/Sources/Pages/frmMarca.aspx");
        }
    }
}