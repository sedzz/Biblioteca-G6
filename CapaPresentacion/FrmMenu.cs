using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //FrmUsuarios frmUsuarios = new FrmUsuarios();
        }

        private void añadirLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAñadirLibro frmAñadirLibro = new FrmAñadirLibro();
            frmAñadirLibro.ShowDialog();
            Hide();
        }

        private void bajaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLectores frmLectores = new FrmLectores();
            frmLectores.Show();
            Hide();
        }

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Devolucion frmdevolucion = new Devolucion();
            frmdevolucion.ShowDialog();
            Hide();
        }

        private void préstamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrestamo frmPrestamo = new FrmPrestamo();
            frmPrestamo.ShowDialog();
            Hide();
        }

        private void morososToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMorosos frmMorosos = new FrmMorosos();
            frmMorosos.ShowDialog();
            Hide();
        }

        private void bajaDeUsuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmLectores frmLectores = new FrmLectores();
            frmLectores.ShowDialog();
            Hide();
        }
    }
}
