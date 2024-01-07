using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Devolucion : Form
    {
        GestorBiblioteca gestorBiblioteca = new GestorBiblioteca();
        List<Libro> librosPrestamoUsuario = new List<Libro>();
        public Devolucion()
        {
            InitializeComponent();
        }

        private void btnIntroducirNumero_Click(object sender, EventArgs e)
        {
            List<Prestamo> listaPrestados = new List<Prestamo>();

            listaPrestados = gestorBiblioteca.LibrosPrestados(tbNumeroCarnet.Text, out string error);

            if (listaPrestados != null)
            {
                cbLibrosDevueltos.Items.Clear();
                foreach (var libro in listaPrestados)
                {
                    Libro lib = gestorBiblioteca.BuscarTituloLibroPorISBN(libro.ISBN_Libro);
                    cbLibrosDevueltos.Items.Add(lib.Titulo);
                    librosPrestamoUsuario.Add(lib);
                }
            }
            else {
                MessageBox.Show(error);
            }
            

        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            String error = "";
            if (cbLibrosDevueltos.SelectedItem != null)
            {
                List<Libro> listaLibrosDevolucion = new List<Libro>();

                foreach (var tituloLibroPrestadoDevuelto in cbLibrosDevueltos.SelectedItems)
                {
                    foreach (var libroPrestado in librosPrestamoUsuario)
                    {
                        if (tituloLibroPrestadoDevuelto.ToString() == libroPrestado.Titulo)
                        {
                            listaLibrosDevolucion.Add(libroPrestado);
                        }
                    }

                }

                gestorBiblioteca.Devolucion(listaLibrosDevolucion, out error);
            }
            else
            {
                MessageBox.Show(error);

            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }
    }
}
