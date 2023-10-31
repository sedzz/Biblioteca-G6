using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace CapaDatos
{
    public class GestorBiblioteca
    {
        const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";  
        DatosBiblioteca biblioteca = new DatosBiblioteca("4V","San Jorge","./logo.png");

        public void AñadirLibro(string isbn, string titulo, string editorial, string sinopsis, string caratula, int unidadesExistentes, string disponibilidad, out string errores) {
            errores = "";

            Libro libro = new Libro(isbn, titulo, editorial, sinopsis, caratula, unidadesExistentes, disponibilidad);

            ; using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();

                    string sqlanyadirLibro = "INSERT INTO Libro (ISBN,Titulo,Editorial,Sinopsis,Caratula,Unidades,Disponibilidad) VALUES (@isbn,@editorial,@sinopsis,@caratula,@unidades,@disponibilidad)";
                    SqlCommand cmdConsulta = new SqlCommand(sqlanyadirLibro, conexion);

                    cmdConsulta.Parameters.AddWithValue("@isbn", isbn);
                    cmdConsulta.Parameters.AddWithValue("@editorial", editorial);
                    cmdConsulta.Parameters.AddWithValue("@sinopsis", sinopsis);
                    cmdConsulta.Parameters.AddWithValue("@caratula", caratula);
                    cmdConsulta.Parameters.AddWithValue("@unidades", unidadesExistentes);
                    cmdConsulta.Parameters.AddWithValue("@disponibilidad", disponibilidad);

                    int filasAfectadas = cmdConsulta.ExecuteNonQuery();


                    string sqlanyadirLectorEscribe = "INSERT INTO Va_Sobre (ISBN_Libro, Id_Categoria) VALUES (@ISBN_Libro, @Id_Categoria)";
                    cmdConsulta.Parameters.AddWithValue("@ISBN_Libro", isbn);
                    /* cmdConsulta.Parameters.AddWithValue("@Id_Categoria", Id_Categoria);*/



                }
                catch (Exception)
                {
                    errores = "Error al agregar el libro";
                    throw;
                }
            }

        }

        public void Prestamo(DateTime fechaPrestamo, DateTime fechaDevolucion, String isbn, String numCarnet, out string errores)
        {

            errores = "";
            try
            {

                using (SqlConnection conexion = new SqlConnection(cadConexion))
                {
                    conexion.Open();
                    string sqlanyadirDevoluciones = "INSERT INTO Toma_Prestado (Fecha_Prestamo,Fecha_Devolucion,ISBN_Libro,NumCarnet) VALUES (@fechaPrestamo,@fechaDevolucion,@isbn,@numCarnet)";
                    SqlCommand anyadirDevolucion = new SqlCommand(sqlanyadirDevoluciones, conexion);

                    anyadirDevolucion.Parameters.AddWithValue("@fechaPrestamo", fechaPrestamo);
                    anyadirDevolucion.Parameters.AddWithValue("@fechaDevolucion", fechaDevolucion);
                    anyadirDevolucion.Parameters.AddWithValue("@isbn", isbn);

                }
            }
            catch
            {

            }

        }

        public List<Lector> Morosos(out string errores)
        {
            errores = "";
            List<Lector> lista = new List<Lector>();

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Toma_Prestado WHERE Toma_Prestado.Fecha_Devolucion < GETDATE()";//INNER JOIN TODO
                    SqlCommand cmdMorosos = new SqlCommand(sql, conexion);
                    SqlDataReader datos = cmdMorosos.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "No se encontraron lectores morosos.";
                    }
                    else
                    {
                        while (datos.Read())
                        {
                            string NumCarnet = datos["NumCarnet"].ToString();

                         //   Lector lector = new Lector(NumCarnet,);
                          //  lista.Add(lector);
                        }

                       
                    }
                        
                }
                catch (Exception exc)
                {
                    errores = "Error al agregar el libro";
                }
                return lista;
            }
        }
    }

}

