using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_Supermercado
{
    public partial class frmInvitado : Form
    {
        public frmInvitado()
        {
            InitializeComponent();
        }

        private void frmInvitado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
