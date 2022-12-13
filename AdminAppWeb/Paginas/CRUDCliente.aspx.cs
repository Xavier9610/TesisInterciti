using System;
using System.Windows.Forms;

namespace AdminAppWeb.Paginas
{
    public partial class CRUDCliente : System.Web.UI.Page
    {
        ServiceReferenceInterciti.ServiceClient usuario = new ServiceReferenceInterciti.ServiceClient();
        ServiceReferenceInterciti.Cliente cliente = new ServiceReferenceInterciti.Cliente();

       

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
            lblInfoCrud.Text = "Desea eliminar el Cliente?";
            int id = Int32.Parse(Request.QueryString["id"].ToString());
            cliente = new ServiceReferenceInterciti.Cliente();
            cliente = usuario.FindClienteByID(id);
            txtNombre.Text = cliente.Nombre;
            txtID.Text = cliente.IdCliente.ToString();
            txtApellido.Text = cliente.Apellido;
            txtCorreo.Text = cliente.Correo;
            txtCI.Text = cliente.Cedula;
            txtTelefono.Text = cliente.Telefono;
            txtFecha.Text = cliente.FechaNacimiento.Date.ToString();

            txtNombre.Enabled = false;
            txtID.Enabled = false;
            txtApellido.Enabled = false;
            txtCorreo.Enabled = false;
            txtCI.Enabled = false;
            txtTelefono.Enabled = false;
            txtFecha.Enabled = false;

            btnGuardar.Text = "Eliminar";
        }

        private void FillUpdate()
        {
            lblInfoCrud.Text = "Editar Cliente";
            int id = Int32.Parse(Request.QueryString["id"].ToString());
            cliente = new ServiceReferenceInterciti.Cliente();
            cliente = usuario.FindClienteByID(id);
            if (btnGuardar.Text != "Guardar")
            {
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Cedula = txtCI.Text;
                cliente.Correo = txtCorreo.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.FechaNacimiento = DateTime.Parse(txtFecha.Text).Date;
            }
            else
            {
                
                
                txtNombre.Text = cliente.Nombre;
                txtID.Text = cliente.IdCliente.ToString();
                txtApellido.Text = cliente.Apellido;
                txtCorreo.Text = cliente.Correo;
                txtCI.Text = cliente.Cedula;
                txtTelefono.Text = cliente.Telefono;
                txtFecha.Text = cliente.FechaNacimiento.ToString();

                txtNombre.Enabled = true;
                txtID.Enabled = false;
                txtApellido.Enabled = true;
                txtCorreo.Enabled = true;
                txtCI.Enabled = true;
                txtTelefono.Enabled = true;
                txtFecha.Enabled = true;

                btnGuardar.Text = "Actualizar";

            }

        }

        private void FillCreate()
        {
            lblInfoCrud.Text = "Nuevo Cliente";

            txtNombre.Enabled = true;
            txtID.Enabled = false;
            txtApellido.Enabled = true;
            txtCorreo.Enabled = true;
            txtCI.Enabled = true;
            txtTelefono.Enabled = true;
            txtFecha.Enabled = true;

            btnGuardar.Text = "Crear";
           
        }

        protected void btnCalendario_Clicked(object sender, EventArgs e)
        {
            cFechaNacimiento.Visible = true;
        }
        protected void btnGuardar_Clicked(object sender, EventArgs e)
        {
            MessageBox.Show(txtNombre.Text, "info",MessageBoxButtons.OK);
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Cedula = txtCI.Text;
            cliente.Correo = txtCorreo.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.FechaNacimiento = DateTime.Parse(txtFecha.Text).Date;
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
            if (usuario.EliminarCliente(cliente.IdCliente) == 0)
            {
                Response.Redirect("Cliente.aspx?sts=ok&op=D");
            }
            else
            {
                Response.Redirect("Cliente.aspx?sts=Fail&op=D");
            }
        }

        private void SaveUpdate_Client()
        {
            //ServiceReferenceInterciti.Cliente cliente = usuario.FindClienteByID(Int32.Parse(Request.QueryString["id"].ToString()));
            

            MessageBox.Show("Se cambiara el nombre "+ cliente.IdCliente+","+cliente.Nombre+ " por: "+ txtID.Text , "info", MessageBoxButtons.OK);
            
            if (usuario.ActualizarCliente(cliente)  != -1)
            {
                Response.Redirect("Cliente.aspx?sts=ok&op=U");
            }
            else
            {
                Response.Redirect("Cliente.aspx?sts=Fail&op=U");
            }
        }

        private void SaveNew_Client()
        {
            if (usuario.AgregarCliente(txtNombre.Text, "PASS", txtApellido.Text, txtCI.Text, txtCorreo.Text, txtTelefono.Text, DateTime.Now.Date) == 0)
            {
                Response.Redirect("Cliente.aspx?sts=ok&op=C");
            }
            else
            {
                Response.Redirect("Cliente.aspx?sts=Fail&op=C");
            }
        }

        protected void cFecha_Clicked(object sender, EventArgs e)
        {
            txtFecha.Text = cFechaNacimiento.SelectedDate.ToString();
            cFechaNacimiento.Visible = false;
        }

        protected void btnVolver_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }
        protected void TxtNombre_TextChanged1(object sender, EventArgs e)
        {
            txtNombre.Text = txtNombre.Text;
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

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            cliente.Nombre = TextBox1.Text;
        }
    }
}