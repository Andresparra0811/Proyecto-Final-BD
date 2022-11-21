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

namespace Proyecto_Final_Supermercado
{
    public partial class frmPrincipal_Usuario : Form
    {
        public frmPrincipal_Usuario()
        {
            InitializeComponent();
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
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            
            this.Close();

            Program.formularioPrincipal.Show();
        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
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
    }
}
