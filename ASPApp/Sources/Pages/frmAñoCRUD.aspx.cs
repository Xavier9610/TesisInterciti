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
    public partial class frmAñoCRUD : System.Web.UI.Page
    {
        private AñoVehiculo año;
        private ServiceClient client = new ServiceClient("BasicHttpsBinding_IService", "https://wcfserviceappinterciti.azurewebsites.net/Service.svc");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Request.QueryString["id"].ToString() + "')", true);
                    año = client.FindAñoVehiculoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                }
                if (Request.QueryString["op"] != null)
                {
                    var op = Request.QueryString["op"];
                    switch (op)
                    {
                        case "C":
                            txtAño.Enabled = true;
                            lblTitulo.Text = "Nuevo Tipo";
                            btnRegistrar.Text = "Nuevo";
                            btnRegistrar.Visible=true;
                            btnRegistrar.Enabled = true;
                            break;
                        case "R":
                            txtAño.Enabled = false;
                            btnRegistrar.Visible = false;
                            btnRegistrar.Enabled = false;
                            txtAño.Text = año.Año;
                            lblTitulo.Text = "Mostrar Tipo";

                            break;
                        case "U":
                            txtAño.Enabled = true;
                            txtAño.Text = año.Año;
                            btnRegistrar.Visible = true;
                            btnRegistrar.Enabled = true;
                            lblTitulo.Text = "Actualizar Tipo";
                            btnRegistrar.Text = "Guardar Cambios";
                            break;
                    }
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtAño != null)
            {
                if (txtAño.Text != "")
                {
                    switch (lblTitulo.Text)
                    {
                        case "Nuevo Tipo":
                            var aux = Servicio.client.GenerarPass();
                            if (Servicio.client.AgregarAñoVehiculo(txtAño.Text) == 0)
                            {
                                Response.Redirect("/Sources/Pages/frmAño.aspx");
                            }
                            else
                            {
                                lblInfo.Text = "Error de registro";
                                //no registrado
                                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
                        case "Actualizar Tipo":
                            año = client.FindAñoVehiculoById(Convert.ToInt32(Request.QueryString["id"].ToString()));
                            año.Año = txtAño.Text;
                            if (Servicio.client.ActualizarAnio(año) == 0)
                            {
                                //exitoso
                                //           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);
                                Response.Redirect("/Sources/Pages/frmAño.aspx");
                            }
                            else
                            {
                                lblInfo.Text = "Error de registro";
                                //no registrado
                                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro erroneo')", true);
                            }
                            break;
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
                //datos mal
                lblInfo.Text = "Datos vacios.";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Datos vacios')", true);
            }


        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/frmAño.aspx");
        }
    }
}