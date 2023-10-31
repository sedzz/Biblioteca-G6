using Entidades;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class GestorBiblioteca
    {
        const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";  
        DatosBiblioteca biblioteca = new DatosBiblioteca("4V","San Jorge","./logo.png");
        public void AñadirLibro(string isbn, string titulo, string editorial, string sinopsis, string caratula, int unidadesExistentes, string disponibilidad, List<Autor> autores, List<Categoria> categorias, out string errores) {
            errores = "";

            Libro libro = new Libro(isbn, titulo, editorial, sinopsis, caratula, unidadesExistentes, disponibilidad);

            ; using (SqlConnection conexion = new SqlConnection(cadConexion))
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

<<<<<<< HEAD
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
            catch
            {

            }

        }

=======
        public List<Lector> Morosos(out string errores)
        {
            errores = "";
            List<Lector> lista = new List<Lector>();
>>>>>>> 2ced3faf757506d9fd9b39e00a80a5a8bcfd8d61

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

