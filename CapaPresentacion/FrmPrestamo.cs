using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using Entidades;

namespace CapaPresentacion
{
    public partial class FrmPrestamo : Form
    {
        public FrmPrestamo()
        {
            InitializeComponent();
        }

        private void btnHacerPrestamo_Click(object sender, EventArgs e)
        {
            string lector = txtNumCarnet.Text;
            string isbn = txtISBN.Text;
            DateTime fechaEntrega = DateTime.Parse(dateFinal.Text);
            string errores = null;

            if(string.IsNullOrWhiteSpace(lector) )
            {
                MessageBox.Show("El identificador del Lector no puede quedar vacio"); return;
            }

            if(string.IsNullOrWhiteSpace(isbn) )
            {
                MessageBox.Show("ISBN del libro invalido"); return;
            }

            if(fechaEntrega < DateTime.Now.AddDays(15))
            {
                MessageBox.Show("La fecha de entrega debe ser mayor a 15 dias"); return;
            }

            Lector prestatario = Consultas.BuscarLectorPorID(lector);
            Libro libro = Consultas.BuscarLibroPorISBN(isbn);
            GestorBiblioteca gestorBiblioteca = Program.gestion;
          
            if(prestatario == null )
            {
                MessageBox.Show("Identificador de Prestatario Invalido");return;
            }

            if(libro == null)
            {
                MessageBox.Show("ISBN del libro invalido"); return;
            }

            gestorBiblioteca.Prestamo(DateTime.Now, fechaEntrega, isbn, lector, out errores);

            if (!string.IsNullOrWhiteSpace(errores))
            {
                MessageBox.Show(errores); return;
            }

            lblNombreLibro.Text = libro.Titulo;
            lblResultado.Text = "Libro Prestado Correctamente";
            lblCantidadLibros.Text = "Libros Restantes : "+libro.UnidadesExistentes.ToString();

        }
    }
}
