using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_presentacion;
using Capa_Datos;

namespace Proyecto_Final_Supermercado
{
    public partial class FormFactura : Form
    {
        ClasePresentacion objpres = new ClasePresentacion();
        ClaseDatos objDatos = new ClaseDatos();
        public FormFactura()
        {
            InitializeComponent();
        }
        
        private void FormFactura_Load(object sender, EventArgs e)
        {
            string nombre = frmPrincipal_Usuario.N_Cliente;
            labelNombre.Text = nombre;
            lblCedula.Text = frmPrincipal_Usuario.cedula.ToString();
            dataGridView1.DataSource = objDatos.D_listar_productosFactura(nombre);
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }
    }
}
