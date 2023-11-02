using System;
using CapaDatos;
using Entidades;
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
    public partial class frmLibros : Form
    {
        public frmLibros()
        {
            
        }

        private void frmLibros_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            dgvLibros.Rows.Clear();

            string titulo = txtBuscar.Text;

            string errores;

            List<Libro> libros = Consultas.BuscarLibroPorPorcionTitulo(titulo, out errores);
            
            dgvLibros.DataSource = libros;

        }
    }
}
