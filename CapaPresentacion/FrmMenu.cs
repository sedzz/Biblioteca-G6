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
        }
    }
}
