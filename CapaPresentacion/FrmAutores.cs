using CapaDatos;
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
    public partial class FrmAutores : Form
    {
        public FrmAutores()
        {
            InitializeComponent();
        }

        

        private void btnAñadirAutor_Click(object sender, EventArgs e)
        {
            GestorBiblioteca gestorBiblioteca = Program.gestion;
            string autor = txtNombreAutor.Text;
            string errores = null;

            if (string.IsNullOrWhiteSpace(autor))
            {
                MessageBox.Show("El nombre del autor no puede quedar vacio"); return;
            }

            gestorBiblioteca.AñadirAutor(autor, out errores);

            if (!string.IsNullOrWhiteSpace(errores))
            {
                MessageBox.Show(errores); return;
            }
           
            MessageBox.Show("Autor añadido correctamente");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
            
        }
    }
}
