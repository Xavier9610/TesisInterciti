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
    public partial class frmModeloCRUD : System.Web.UI.Page
    {
        private ModeloVehiculo modelo;
        private ServiceClient client = new ServiceClient("BasicHttpsBinding_IService", "https://wcfserviceappinterciti.azurewebsites.net/Service.svc");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Request.QueryString["id"].ToString() + "')", true);
                    modelo = client.FindModeloVehiculoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                }
                if (Request.QueryString["op"] != null)
                {
                    var op = Request.QueryString["op"];
                    switch (op)
                    {
                        case "C":
                            txtModelo.Enabled = true;
                            btnRegistrar.Visible = true;
                            btnRegistrar.Enabled = true;
                            marca.Enabled = true;
                            lblTitulo.Text = "Nuevo Modelo";
                            btnRegistrar.Text = "Nuevo";
                            break;
                        case "R":
                            txtModelo.Enabled = false;
                            txtModelo.Text = modelo.Modelo;
                            btnRegistrar.Visible = false;
                            btnRegistrar.Enabled = false;
                            marca.Enabled = false;
                            marca.SelectedValue = modelo.IdMarca.ToString();
                            lblTitulo.Text = "Mostrar Modelo";

                            break;
                        case "U":
                            txtModelo.Enabled = true;
                            btnRegistrar.Visible = true;
                            btnRegistrar.Enabled = true;
                            marca.Enabled = true;
                            txtModelo.Text = modelo.Modelo;
                            marca.SelectedValue = modelo.IdMarca.ToString();
                            lblTitulo.Text = "Actualizar Modelo";
                            btnRegistrar.Text = "Guardar Cambios";
                            break;
                    }
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtModelo != null && marca.SelectedValue!="0")
            {
                if (txtModelo.Text != "")
                {
                    switch (lblTitulo.Text)
                    {
                        case "Nuevo Modelo":
                            if (Servicio.client.AgregarModeloVehiculo(txtModelo.Text, Convert.ToInt32(marca.SelectedValue)) == 0)
                            {
                                Response.Redirect("/Sources/Pages/frmModelo.aspx");
                            }
                            else
                            {
                                //no registrado
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
                        case "Actualizar Modelo":
                            modelo = client.FindModeloVehiculoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                            modelo.Modelo = txtModelo.Text;
                            modelo.IdMarca = Convert.ToInt32( marca.SelectedValue);
                            if (Servicio.client.ActualizarModelo(modelo) == 0)
                            {
                                //exitoso
                                //           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                Response.Redirect("/Sources/Pages/frmModelo.aspx");
                            }
                            else
                            {
                                //no registrado
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmModelo.aspx");
        }
    }
}