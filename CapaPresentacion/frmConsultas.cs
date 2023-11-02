using Entidades;
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
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
        }


        private void btnLibroTrozoNombre_Click(object sender, EventArgs e)
        {
            dgvResultados.Rows.Clear();
            List<Libro> libros = Consultas.BuscarLibroPorPorcionTitulo(txtBuscar.Text, out string errores);
            dgvResultados.DataSource = libros;
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
