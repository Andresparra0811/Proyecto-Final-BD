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
using System.Runtime.Remoting;

namespace Proyecto_Final_Supermercado
{
    public partial class frmPrincipal_Usuario : Form
    {
        ClaseLogica objlog = new ClaseLogica();
        ClasePresentacion objpres = new ClasePresentacion();
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
            objlog.ID_factura = Convert.ToInt32(txtfactura.Text);
            string men = objpres.N_CUD(objlog);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void limpiar()
        {
            txtID.Text = "0";
            txtnombre.Text = "";
            txtcantidad.Text = "0";
            txtfactura.Text = "";
            dataGridView1.DataSource = objpres.N_listar_productos();
        }






        private void frmPrincipal_Usuario_Load(object sender, EventArgs e)
        {
            if (FormLogin.InvitadoCheck)
            {
                string user = FormLogin.NombreUsuario;
                btnBuscar.Enabled = true;
                btnBorrar.Enabled = false;
                btnEditar.Enabled = false;
                btnAgregar.Enabled = false;
                btnNuevo.Enabled = false;
                labelUsuario.Text = user;
            }
            else
            {
                string user = FormLogin.NombreUsuario;
                btnBuscar.Enabled = true;
                btnBorrar.Enabled = true;
                btnEditar.Enabled = true;
                btnAgregar.Enabled = true;
                btnNuevo.Enabled = true;
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
            txtfactura.Text = dataGridView1[3, fila].Value.ToString();

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
    }
}
