using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AdminAppWeb.Paginas
{
    public partial class CRUDVehiculo : System.Web.UI.Page
    {
        ServiceReferenceInterciti.ServiceClient usuario = new ServiceReferenceInterciti.ServiceClient();
        ServiceReferenceInterciti.Vehiculo cliente = new ServiceReferenceInterciti.Vehiculo();



        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["op"] != null)
                {
                    switch (Request.QueryString["op"].ToString())
                    {
                        case "C":
                            FillCreate();
                            break;
                        case "U":
                            FillUpdate();
                            break;
                        case "D":
                            FillDelete();
                            break;
                        default:
                            // code block
                            break;
                    }
                }
            }


        }

        private void FillDelete()
        {

            lblInfoCrud.Text = "Desea eliminar el Vehiculo?";
            int id = Int32.Parse(Request.QueryString["id"].ToString());
            cliente = new ServiceReferenceInterciti.Vehiculo();
            cliente = usuario.FindVehiculoByID(id);
            txtPlacaVehiculo.Text = cliente.Placa;
            ddlMarca.SelectedValue = cliente.Marca1;
            ddlModelo.SelectedValue = cliente.Modelo1;
            ddlAño.SelectedValue = cliente.Año1;
            txtIDVehiculo.Text = cliente.IdVehiculo.ToString();
            txtIDVehiculo.Enabled = false;
            txtPlacaVehiculo.Enabled = false;

            btnGuardarVehiculo.Text = "Eliminar";
        }

        private void FillUpdate()
        {
            
            lblInfoCrud.Text = "Editar Conductor";
            int id = Int32.Parse(Request.QueryString["id"].ToString());
            cliente = new ServiceReferenceInterciti.Vehiculo();
            cliente = usuario.FindVehiculoByID(id);
            MessageBox.Show("Valor de: " + cliente.Marca1, "", MessageBoxButtons.OK);
            if (btnGuardarVehiculo.Text != "Guardar")
            {
                cliente.IdVehiculo = Int32.Parse( txtIDVehiculo.Text);
                cliente.Tipo1 = ddlTipo.SelectedValue;
                cliente.Marca1 = ddlMarca.SelectedValue ;
                cliente.Modelo1 = ddlModelo.SelectedValue ;
                cliente.Año1 = ddlAño.SelectedValue;
                cliente.Placa = txtPlacaVehiculo.Text ;
            }
            else
            {


                txtIDVehiculo.Text = cliente.IdVehiculo.ToString();
                txtPlacaVehiculo.Text = cliente.Placa;
                ddlMarca.SelectedValue = cliente.Marca1;
                ddlModelo.SelectedValue = cliente.Modelo1;
                ddlAño.SelectedValue = cliente.Año1;
                ddlTipo.SelectedValue = cliente.Tipo1;
                txtIDVehiculo.Enabled = false;
                txtPlacaVehiculo.Enabled = true;

                btnGuardarVehiculo.Text = "Actualizar";

            }

        }

        private void FillCreate()
        {
            lblInfoCrud.Text = "Nuevo Conductor";

            txtIDVehiculo.Enabled = false;
            txtPlacaVehiculo.Enabled = true;


            btnGuardarVehiculo.Text = "Crear";

        }

        
        protected void btnGuardarVehiculo_Clicked(object sender, EventArgs e)
        {
            cliente.Marca1 = ddlMarca.SelectedItem.Text;
            cliente.Modelo1 = ddlModelo.SelectedItem.Text;
            cliente.Placa = txtPlacaVehiculo.Text;
            cliente.Tipo1 = ddlTipo.SelectedItem.Text;
            cliente.Año1 = ddlAño.SelectedItem.Text;
            if (Request.QueryString["op"] != null)
            {
                switch (Request.QueryString["op"].ToString())
                {
                    case "C":
                        SaveNew_Client();
                        break;
                    case "U":
                        SaveUpdate_Client();
                        break;
                    case "D":
                        SaveDelete_Client();
                        break;
                    default:
                        // code block
                        break;
                }
            }
        }

        private void SaveDelete_Client()
        {
            if (usuario.EliminarVehiculo(Int32.Parse(txtIDVehiculo.Text)) == 0)
            {
                Response.Redirect("Vehiculo.aspx?sts=ok&op=D");
            }
            else
            {
                Response.Redirect("Vehiculo.aspx?sts=Fail&op=D");
            }
        }

        private void SaveUpdate_Client()
        {
            //ServiceReferenceInterciti.Cliente cliente = usuario.FindClienteByID(Int32.Parse(Request.QueryString["id"].ToString()));


            MessageBox.Show("Se cambiara el nombre " + cliente.Modelo1 + "," + ddlModelo.SelectedValue + " por: " , "info", MessageBoxButtons.OK);

            if (usuario.ActualizarVehiculo(cliente) != -1)
            {
                Response.Redirect("Vehiculo.aspx?sts=ok&op=U");
            }
            else
            {
                Response.Redirect("Vehiculo.aspx?sts=Fail&op=U");
            }
        }

        private void SaveNew_Client()
        {

            if (usuario.AgregarVehiculo(txtPlacaVehiculo.Text,usuario.FindMarcaVehiculoByMarca(ddlMarca.SelectedValue), usuario.FindMarcaVehiculoByMarca(ddlMarca.SelectedValue), usuario.FindMarcaVehiculoByMarca(ddlMarca.SelectedValue), usuario.FindMarcaVehiculoByMarca(ddlMarca.SelectedValue)) == 0)
            {
                Response.Redirect("Vehiculo.aspx?sts=ok&op=C");
            }
            else
            {
                Response.Redirect("Vehiculo.aspx?sts=Fail&op=C");
            }
        }


        protected void btnVolver_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Vehiculo.aspx");
        }
        protected void TxtNombre_TextChanged1(object sender, EventArgs e)
        {
            //txtNombre.Text = txtNombre.Text;
            //   MessageBox.Show("Se cambiara el nombre " + cliente.Nombre + " por: " + TextBox1.Text, "Eror", MessageBoxButtons.OK);

        }
        protected void TxtApellido_TextChanged1(object sender, EventArgs e)
        {
            //cliente.Apellido = txtApellido.Text;
        }
        protected void TxtCI_TextChanged1(object sender, EventArgs e)
        {
            //cliente.Cedula = txtCI.Text;
        }
        protected void TxtCorreo_TextChanged1(object sender, EventArgs e)
        {
            //cliente.Correo = txtCorreo.Text;
        }
        protected void TxtTelefono_TextChanged1(object sender, EventArgs e)
        {
            //cliente.Telefono = txtTelefono.Text;
        }
        protected void TxtFecha_TextChanged1(object sender, EventArgs e)
        {
            //cliente.FechaNacimiento = DateTime.Parse(txtFecha.Text);
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectDataSource objectData = new ObjectDataSource();
            //Poner los modelos acorde a la marca

        }
        
            protected void btnAgregarModeloVehiculo_Clicked(object sender, EventArgs e)
        {
            txtModelo.Visible = true;
            
        }
        
           protected void btnAgregarMarcaVehiculo_Clicked(object sender, EventArgs e)
        {
            txtMarcaNew.Visible = true;
            
        }
        
            protected void btnGuardarModeloVehiculo_Clicked(object sender, EventArgs e)
        {
            txtModelo.Visible = false;
            
        }
        protected void btnGuardarMarcaVehiculo_Clicked(object sender, EventArgs e)
        {
            txtMarcaNew.Visible = false;
                    
        }
        
            protected void btnGuardarTipoVehiculo_Clicked(object sender, EventArgs e)
        {
            txtMarcaNew.Visible = false;

        }
        protected void btnAgregarTipoVehiculo_Clicked(object sender, EventArgs e)
        {
            txtMarcaNew.Visible = false;

        }

        protected void DdlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("nombre :" + ddlModelo.SelectedItem.Value, "info", MessageBoxButtons.OK);
        }

        
    }
}