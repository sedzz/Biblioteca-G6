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
        public void AñadirLibro(string isbn, string titulo, string editorial, string sinopsis, string caratula, int unidadesExistentes, string disponibilidad, List<Autor> autores, List<Categoria> categorias, out string errores) {
            errores = "";
            
            Libro libro = new Libro(isbn,titulo,editorial,sinopsis,caratula,unidadesExistentes,disponibilidad);

;            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();

                    string sqlAnyadirLibro = "INSERT INTO Libro (ISBN,Titulo,Editorial,Sinopsis,Caratula,Unidades,Disponibilidad) VALUES (@isbn,@editorial,@sinopsis,@caratula,@unidades,@disponibilidad)";
                    SqlCommand cmdInsertarLibro = new SqlCommand(sqlAnyadirLibro, conexion);

                    cmdInsertarLibro.Parameters.AddWithValue("@isbn", isbn);
                    cmdInsertarLibro.Parameters.AddWithValue("@editorial", editorial);
                    cmdInsertarLibro.Parameters.AddWithValue("@sinopsis", sinopsis);
                    cmdInsertarLibro.Parameters.AddWithValue("@caratula", caratula);
                    cmdInsertarLibro.Parameters.AddWithValue("@unidades", unidadesExistentes);
                    cmdInsertarLibro.Parameters.AddWithValue("@disponibilidad", disponibilidad);

                    int filasAfectadas = cmdInsertarLibro.ExecuteNonQuery();


                    string sqlAnyadirVaSobre = "INSERT INTO Va_Sobre (ISBN_Libro, Id_Categoria) VALUES (@ISBN_Libro, @Id_Categoria)";


                    for (int i = 0; i < categorias.Count; i++)
                    {
                        SqlCommand cmdInsertarVaSobre = new SqlCommand(sqlAnyadirVaSobre, conexion);
                        cmdInsertarVaSobre.Parameters.AddWithValue("@ISBN_Libro", isbn);
                        cmdInsertarVaSobre.Parameters.AddWithValue("Id_Categoria", categorias[i]);
                        cmdInsertarVaSobre.ExecuteNonQuery();
                    }


                    string sqlAnyadirEscribe = "INSERT INTO Escribe (ISBN_Libro, Id_Autor) VALUES (@ISBN_Libro, @Id_Autor)";


                    for (int i = 0; i < autores.Count; i++)
                    {
                        SqlCommand cmdInsertarVaSobre = new SqlCommand(sqlAnyadirVaSobre, conexion);
                        cmdInsertarVaSobre.Parameters.AddWithValue("@ISBN_Libro", isbn);
                        cmdInsertarVaSobre.Parameters.AddWithValue("Id_Autor", autores[i]);
                        cmdInsertarVaSobre.ExecuteNonQuery();
                    }
             
                }
                catch (Exception)
                {
                    errores = "Error al agregar el libro";
                    throw;
                }
            }
            
        }


        public void BorrarLibro(string Isbn_Libro, out string errores) 
        {
            
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();

                    string sqlBuscarLibro = "SELECT * FROM Libro WHERE ISBN = @isbn";

                    SqlCommand cmdBuscarLibro = new SqlCommand(sqlBuscarLibro, conexion);

                    cmdBuscarLibro.Parameters.AddWithValue("@isbn", Isbn_Libro);
                    
                    SqlDataReader libro = cmdBuscarLibro.ExecuteReader();

                    if (libro.Read())
                    {

                        string sqlBuscarPrestamos = "SELECT * FROM Toma_prestado WHERE ISBN_Libro = @isbn";

                        SqlCommand cmdBuscarPrestamos = new SqlCommand(sqlBuscarPrestamos, conexion);

                        cmdBuscarPrestamos.Parameters.AddWithValue("@isbn", Isbn_Libro);

                        SqlDataReader prestamos = cmdBuscarPrestamos.ExecuteReader();

                        if (prestamos.Read())
                        {
                            errores = "El libro tiene unidades prestadas. No se ha borrado de la biblioteca.";
                        } else
                        {

                            string sqlBorrarVaSobre = "DELETE FROM Va_Sobre WHERE Isbn_libro = @isbn";

                            SqlCommand cmdBorrarVaSobre = new SqlCommand(sqlBorrarVaSobre, conexion);

                            cmdBorrarVaSobre.Parameters.AddWithValue("@isbn", Isbn_Libro);

                            cmdBorrarVaSobre.ExecuteNonQuery();

                            string sqlBorrarEscribe = "DELETE FROM Escribe WHERE Isbn_libro = @isbn";

                            SqlCommand cmdBorrarEscribe = new SqlCommand(sqlBorrarEscribe, conexion);

                            cmdBorrarEscribe.Parameters.AddWithValue("@isbn", Isbn_Libro);

                            cmdBorrarEscribe.ExecuteNonQuery();

                            string sqlBorrarLibro = "DELETE FROM Escribe WHERE Isbn_libro = @isbn";

                            SqlCommand cmdBorrarLibro= new SqlCommand(sqlBorrarLibro, conexion);

                            cmdBorrarLibro.Parameters.AddWithValue("@isbn", Isbn_Libro);

                            cmdBorrarLibro.ExecuteNonQuery();

                            errores = "";

                        }

                    }

                    errores = "No existe un libro con ese ISBN";

                }
                catch (Exception)
                {
                    errores = "Error al intentar borrar el libro";
                    throw;
                }
            }


        }
        


    }
}

