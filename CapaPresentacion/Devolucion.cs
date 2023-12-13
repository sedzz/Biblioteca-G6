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
        public Devolucion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbNumeroCarnet_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIntroducirNumero_Click(object sender, EventArgs e)
        {
            const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";
            String errores = "";
            string numcarnetstr = tbNumeroCarnet.Text;
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                  
                try{ 
                    conexion.Open();
                    string sqlanyadirLibro = $"SELECT COUNT() FROM Lector WHERE NumCarnet = '{numcarnetstr}';";
                    SqlCommand existeUnLector = new SqlCommand(sqlanyadirLibro, conexion);

                    SqlDataReader resultadoExisteLector = existeUnLector.ExecuteReader();

                    if (resultadoExisteLector.FieldCount != -1)
                    {
                        string consultaLibrosDeUnLector = $"SELECT ISBN_Libro FROM Toma_Prestado WHERE NumCarnet = '{numcarnetstr}';";
                        SqlCommand librosDeUnLector = new SqlCommand(consultaLibrosDeUnLector, conexion);

                        SqlDataReader resultadoLibroDeUnLector = librosDeUnLector.ExecuteReader();

                        while (resultadoLibroDeUnLector.Read())
                        {
                            cbLibrosDevueltos.Items.Add(resultadoLibroDeUnLector["ISBN_Libro"].ToString());
                        }

                    }
                    else {
                        MessageBox.Show(Text = $"No se ha encontrado un lector");
                    }
                }
                catch (Exception){
                    errores = "Error al agregar el libro";
                    throw;

                }
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (cbLibrosDevueltos.SelectedItem != null)
            {
                const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";
                String errores = "";
                using (SqlConnection conexion = new SqlConnection(cadConexion))
                {
                    string libroParaDevolver = cbLibrosDevueltos.SelectedItem.ToString();
                    string consultaEliminarLibroPrestado = $"DELETE FROM Toma_Prestado WHERE Isbn_libro = @isbn"; ;
                    SqlCommand EliminarLibroPrestado = new SqlCommand(consultaEliminarLibroPrestado, conexion);

                    EliminarLibroPrestado.Parameters.AddWithValue("@isbn", libroParaDevolver);

                    int numDeFilasAceptadas = EliminarLibroPrestado.ExecuteNonQuery();

                    errores = "";

                    MessageBox.Show(Text = $"NUMERO DE FILAS ACEPTADAS {numDeFilasAceptadas}");
                }
            }
            else {
                MessageBox.Show(Text = $"No hay un libro seleccionado");

            }
        }
    }
}
