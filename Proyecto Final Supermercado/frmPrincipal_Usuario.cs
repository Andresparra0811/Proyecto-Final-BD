using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Capa_Logica;
using Capa_presentacion;
using Capa_Datos;
using System.Runtime.Remoting;
using Microsoft.VisualBasic;

namespace Proyecto_Final_Supermercado
{
    public partial class frmPrincipal_Usuario : Form
    {
        ClaseLogica objlog = new ClaseLogica();
        ClasePresentacion objpres = new ClasePresentacion();
        String ProductosFactura = "";
        static public String N_Cliente = "";
        static public int cedula = 0;
        ClaseDatos objdatos = new ClaseDatos();

        public frmPrincipal_Usuario()
        {
            InitializeComponent();
        }

        void CUD(string accion)
        {
            objlog.accion = accion;
            objlog.ID_producto = Convert.ToInt32(txtID.Text);
            objlog.Nombre = txtnombre.Text;
            objlog.Cantidad = Convert.ToInt32(txtcantidad.Text);
            objlog.Proveedor = txtProveedor.Text;
            objlog.Precio = Convert.ToInt32(txtPrecio.Text);
            string men = objpres.N_CUD(objlog);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void limpiar()
        {
            txtID.Text = "0";
            txtnombre.Text = "";
            txtcantidad.Text = "0";
            txtProveedor.Text = "";
            txtPrecio.Text = "0";
            dataGridView1.DataSource = objpres.N_listar_productos();
        }






        private void frmPrincipal_Usuario_Load(object sender, EventArgs e)
        {
            if (FormLogin.InvitadoCheck)
            {
                string user = FormLogin.NombreUsuario;
                btnBuscar.Enabled = true;
                btnBorrar.Enabled = false;
                btnBorrar.BackColor = Color.White;
                btnEditar.Enabled = false;
                btnEditar.BackColor = Color.White;
                btnAgregar.Enabled = false;
                btnAgregar.BackColor = Color.White;
                btnNuevo.Enabled = false;
                btnNuevo.BackColor = Color.White;
                btnAgregarFactura.Enabled = false;
                btnAgregarFactura.BackColor = Color.White;
                btnVerFactura.Enabled = false;
                btnVerFactura.BackColor = Color.White;
                labelUsuario.Text = user;
            }
            else
            {
                string user = FormLogin.NombreUsuario;
                btnBuscar.Enabled = true;
                btnBuscar.BackColor = Color.FromArgb(51, 51, 255);
                btnBorrar.Enabled = true;
                btnBorrar.BackColor = Color.FromArgb(51, 51, 255);
                btnEditar.Enabled = true;
                btnEditar.BackColor = Color.FromArgb(51, 51, 255);
                btnAgregar.Enabled = true;
                btnAgregar.BackColor = Color.FromArgb(51, 51, 255);
                btnNuevo.Enabled = true;
                btnNuevo.BackColor = Color.FromArgb(51, 51, 255);
                btnAgregarFactura.Enabled = true;
                btnAgregarFactura.BackColor = Color.FromArgb(51, 51, 255);
                btnVerFactura.Enabled = true;
                btnVerFactura.BackColor = Color.FromArgb(51, 51, 255);
                labelUsuario.Text = user;
            }
            dataGridView1.DataSource = objpres.N_listar_productos();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            
            this.Close();

            Program.formularioPrincipal.Show();
        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            txtID.Text = dataGridView1[0, fila].Value.ToString();
            txtnombre.Text = dataGridView1[1, fila].Value.ToString();
            txtcantidad.Text = dataGridView1[2, fila].Value.ToString();
            txtProveedor.Text = dataGridView1[3, fila].Value.ToString();
            txtPrecio.Text = dataGridView1[4, fila].Value.ToString();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtbusqueda.Text != "")
            {
                objlog.Nombre = txtnombre.Text;
                DataTable dt = new DataTable();
                dt = objpres.N_buscar_producto(objlog);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objpres.N_listar_productos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar el producto " + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {

                    CUD("2");
                    limpiar();
                }


            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar el producto " + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {

                    CUD("3");
                    limpiar();
                }


            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtID.Text == "0")
            {
               if (MessageBox.Show("¿Deseas registrar el producto " + txtnombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {

                    CUD("1");
                    limpiar();
                }

            }
        }

        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            if (N_Cliente == "")
            {
                string message, title, defaultValue;
                object myValue;

                string message1, title1, defaultValue1;
                object myValue1;

                message = "Ingrese el nombre del cliente";
                title = "Nombre del cliente";
                defaultValue = "Cliente";

                message1 = "Ingrese la cédula del cliente";
                title1 = "Cédula del cliente";
                defaultValue1 = "000000000";

                myValue1 = Interaction.InputBox(message1, title1, defaultValue1);

                myValue = Interaction.InputBox(message, title, defaultValue);
                if (myValue.ToString() == "" || myValue1.ToString() == "")
                {
                    MessageBox.Show("No se ingreso ningun nombre");
                }
                else
                {
                    N_Cliente = myValue.ToString();
                    cedula = Convert.ToInt32(myValue1.ToString());
                    
                }
            }
            
            ProductosFactura = ProductosFactura + txtnombre.Text + 
                               " - Cantidad: 1 - Precio: " + "$" + 
                               txtPrecio.Text + Environment.NewLine;
            DateTime fecha = DateTime.Now;



            objdatos.registroEnFactura(fecha, ProductosFactura, N_Cliente, cedula);
            MessageBox.Show("Producto registrado en factura con exito");
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            FormFactura factura = new FormFactura();
            

            factura.Show();
        }
    }
}
