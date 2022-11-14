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
    public partial class FormLogin : Form
    {
        SQL_Control_Login sQLControl = new SQL_Control_Login();
        SQL_IngresoUsuario sQLIngreso = new SQL_IngresoUsuario();
        static public Boolean InvitadoCheck;
        static public String NombreUsuario;

        public FormLogin()
        {
            InitializeComponent();
        }
 

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int resultado = sQLControl.Login(TextUsuario.Text, TextPass.Text);
            DateTime fecha = DateTime.Now;
            if (resultado == 1)
            {
                InvitadoCheck = false;
                sQLIngreso.Ingreso(TextUsuario.Text, fecha);
                MessageBox.Show("Bienvenido " + TextUsuario.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NombreUsuario = TextUsuario.Text;
                TextUsuario.Text = "";
                TextPass.Text = "";
                frmPrincipal_Usuario menu = new frmPrincipal_Usuario();
                this.Hide();
                
                //menu.ShowDialog();
                menu.Show();

            }
            else if (resultado == 0)
            {
                MessageBox.Show("Usuario o contraseña invalidos");
                TextUsuario.Text = "";
                TextPass.Text = "";
            }

        }

        private void btnInvitado_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            sQLIngreso.Ingreso("Invitado", fecha);
            InvitadoCheck = true;
            NombreUsuario = "Invitado";
            frmPrincipal_Usuario menu = new frmPrincipal_Usuario();
            this.Hide();
            menu.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
