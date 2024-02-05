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
        GestorBiblioteca gestion = new GestorBiblioteca(); // todo NO puede ser aquí
        public frmLibros()
        {
            InitializeComponent();
        }

        private void frmLibros_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string titulo = txtBuscar.Text;

            string errores;

            List<Libro> libros = Consultas.BuscarLibroPorPorcionTitulo(titulo, out errores);
            dgvLibros.DataSource = libros;

            MessageBox.Show(errores);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dgvLibros.SelectedRows.Count > 0)
            {
                // Confirmar la eliminación con un mensaje
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el libro seleccionado(s)?", "Eliminar Libro(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Iterar sobre las filas seleccionadas y eliminar los libros
                    foreach (DataGridViewRow row in dgvLibros.SelectedRows)
                    {
                        // Obtener el ISBN del libro de la fila actual
                        string isbnLibro = row.Cells["ISBN"].Value.ToString();

                        // Llamar al método BorrarLibro para eliminar el libro
                        gestion.BorrarLibro(isbnLibro, out string errores);
                        MessageBox.Show(errores);   

                    }

                    // Volver a cargar la lista de libros después de la eliminación
                    // Puedes realizar esta carga de datos de acuerdo a tu lógica específica
                    // Por ejemplo, podrías volver a llamar al método btnBuscar_Click para recargar los libros
                    btnBuscar_Click(sender, e);

                    // Informar al usuario que la eliminación fue exitosa
                    MessageBox.Show("Libro(s) eliminado(s) exitosamente", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Mostrar un mensaje si no hay filas seleccionadas
                MessageBox.Show("No hay ningún libro seleccionado para eliminar", "Sin Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            List<Libro> libros = Consultas.BuscarLibroPorPorcionTitulo("", out string errores);
            dgvLibros.DataSource = libros;
            MessageBox.Show(errores);
        }

    }
}

