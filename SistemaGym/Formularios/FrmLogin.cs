using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SistemaGym.DAO;
using SistemaGym.Entidades;

namespace SistemaGym.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el usuario.");
                    txtUsuario.Focus();
                    return;
                }

                if (txtContrasena.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese la contraseña.");
                    txtContrasena.Focus();
                    return;
                }

                UsuarioDAO dao = new UsuarioDAO();

                Usuario usuario = dao.Login(
                    txtUsuario.Text.Trim(),
                    txtContrasena.Text.Trim());

                if (usuario != null)
                {
                    MessageBox.Show("Bienvenido " + usuario.NombreUsuario);

                    FrmMenuPrincipal menu = new FrmMenuPrincipal();

                    menu.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
