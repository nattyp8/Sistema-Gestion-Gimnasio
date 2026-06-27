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

        private void bntEntrenadores_Click(object sender, EventArgs e)
        {
            FrmEntrenadores ventanaEntrenadores = new FrmEntrenadores();
            ventanaEntrenadores.ShowDialog();
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            FrmMembresias ventanaMembresias = new FrmMembresias();
            ventanaMembresias.ShowDialog();
        }

        private void btnClases_Click(object sender, EventArgs e)
        {
            FrmClases ventanaClases = new FrmClases();
            ventanaClases.ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            FrmPagos ventanaPagos = new FrmPagos();
            ventanaPagos.ShowDialog();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FrmInscripciones ventanaInscripciones = new FrmInscripciones();
            ventanaInscripciones.ShowDialog();
        }
    }
}
