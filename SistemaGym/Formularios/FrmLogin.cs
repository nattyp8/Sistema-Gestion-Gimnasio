using SistemaGym.DAO;
using SistemaGym.Entidades;
using SistemaGym.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
                    Mensajes.Validacion("Ingrese el usuario.");
                    txtUsuario.Focus();
                    return;
                }

                if (txtContrasena.Text.Trim() == "")
                {
                    Mensajes.Validacion("Ingrese la contraseña.");
                    txtContrasena.Focus();
                    return;
                }

                UsuarioDAO dao = new UsuarioDAO();

                Usuario usuario = dao.Login(
                    txtUsuario.Text.Trim(),
                    txtContrasena.Text.Trim());

                if (usuario != null)
                {
                    Mensajes.Exito("Bienvenido " + usuario.NombreUsuario);

                    FrmMenuPrincipal menu = new FrmMenuPrincipal();

                    menu.Show();

                    this.Hide();
                }
                else
                {
                    Mensajes.Validacion("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                Mensajes.Error(ex, "iniciar sesión");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
