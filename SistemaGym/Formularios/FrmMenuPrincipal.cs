using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaGym.Formularios
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            FrmSocios ventanaSocios = new FrmSocios();
            ventanaSocios.ShowDialog(); // Abre la ventana encima del menú
        }
    }
}
