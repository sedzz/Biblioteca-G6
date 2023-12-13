using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos
{
    public class GestorBiblioteca
    {
        const string cadConexion = "Data Source= DESKTOP-T5I655L\\SEBASERVER; Initial Catalog=BibliotecaG6; Integrated Security=SSPI; MultipleActiveResultSets=true";
        DatosBiblioteca biblioteca = new DatosBiblioteca("4V", "San Jorge", "./logo.png");

        public void AñadirLibro(string isbn, string titulo, string editorial, string sinopsis, string caratula, int unidadesExistentes, string disponibilidad, List<Autor> autores, List<Categoria> categorias, out string errores)
        {
            errores = "";

            Libro libro = new Libro(isbn, titulo, editorial, sinopsis, caratula, unidadesExistentes, disponibilidad);

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();

                    string sqlAnyadirLibro = "INSERT INTO Libro (ISBN, Titulo, Editorial, Sinopsis, Caratula, Unidades, Disponibilidad) " +
                        "VALUES (@isbn, @titulo, @editorial, @sinopsis, @caratula, @unidades, @disponibilidad)";
                    SqlCommand cmdInsertarLibro = new SqlCommand(sqlAnyadirLibro, conexion);

                    cmdInsertarLibro.Parameters.AddWithValue("@isbn", isbn);
                    cmdInsertarLibro.Parameters.AddWithValue("@titulo", titulo);
                    cmdInsertarLibro.Parameters.AddWithValue("@editorial", editorial);
                    cmdInsertarLibro.Parameters.AddWithValue("@sinopsis", sinopsis);
                    cmdInsertarLibro.Parameters.AddWithValue("@caratula", caratula);
                    cmdInsertarLibro.Parameters.AddWithValue("@unidades", unidadesExistentes);
                    cmdInsertarLibro.Parameters.AddWithValue("@disponibilidad", disponibilidad);

                    int filasAfectadas = cmdInsertarLibro.ExecuteNonQuery();

                    string sqlAnyadirVaSobre = "INSERT INTO Va_Sobre (ISBN_Libro, Id_Categoria) VALUES (@isbn, @idCategoria)";
                    SqlCommand cmdInsertarVaSobre = new SqlCommand(sqlAnyadirVaSobre, conexion);

                    foreach (var categoria in categorias)
                    {
                        cmdInsertarVaSobre.Parameters.Clear();
                        cmdInsertarVaSobre.Parameters.AddWithValue("@isbn", isbn);
                        cmdInsertarVaSobre.Parameters.AddWithValue("@idCategoria", categoria.Id); // Asumo que Id es la propiedad correcta
                        cmdInsertarVaSobre.ExecuteNonQuery();
                    }

                    string sqlAnyadirEscribe = "INSERT INTO Escribe (ISBN_Libro, Id_Autor) VALUES (@isbn, @idAutor)";
                    SqlCommand cmdInsertarEscribe = new SqlCommand(sqlAnyadirEscribe, conexion);

                    foreach (var autor in autores)
                    {
                        cmdInsertarEscribe.Parameters.Clear();
                        cmdInsertarEscribe.Parameters.AddWithValue("@isbn", isbn);
                        cmdInsertarEscribe.Parameters.AddWithValue("@idAutor", autor.Id); // Asumo que Id es la propiedad correcta
                        cmdInsertarEscribe.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    errores = "Error al agregar el libro: " + e;
                    throw;
                }
            }
        }

        public void Prestamo(DateTime fechaPrestamo, DateTime fechaDevolucion, string isbn, string numCarnet, out string errores)
        {
            errores = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadConexion))
                {
                    conexion.Open();

                    string sqlVerificarExistenciaLibro = "SELECT ISBN FROM Libro WHERE ISBN = @isbn";
                    SqlCommand verificarExistenciaLibro = new SqlCommand(sqlVerificarExistenciaLibro, conexion);
                    verificarExistenciaLibro.Parameters.AddWithValue("@isbn", isbn);
                    var libroExistente = verificarExistenciaLibro.ExecuteScalar();

                    if (libroExistente == null)
                    {
                        errores = "El libro seleccionado no existe";
                    }
                    else
                    {
                        string sqlVerificarDisponibilidad = "SELECT Disponibilidad FROM Libro WHERE ISBN = @isbn";
                        SqlCommand verificarDisponibilidadCmd = new SqlCommand(sqlVerificarDisponibilidad, conexion);
                        verificarDisponibilidadCmd.Parameters.AddWithValue("@isbn", isbn);
                        string disponibilidad = (string)verificarDisponibilidadCmd.ExecuteScalar();

                        if (disponibilidad != "Prestable")
                        {
                            errores = "El libro no está disponible para préstamo";
                        }
                        else
                        {

                            string sqlVerificarMorosidad = "SELECT COUNT(*) FROM Toma_Prestado " +
                                "WHERE NumCarnet = @numCarnet AND Fecha_Devolucion < @fechaActual";
                            SqlCommand verificarMorosidadCmd = new SqlCommand(sqlVerificarMorosidad, conexion);
                            verificarMorosidadCmd.Parameters.AddWithValue("@numCarnet", numCarnet);
                            verificarMorosidadCmd.Parameters.AddWithValue("@fechaActual", DateTime.Now);
                            int prestamosMorosos = (int)verificarMorosidadCmd.ExecuteScalar();

                            if (prestamosMorosos > 0)
                            {
                                errores = "El usuario tiene préstamos morosos. No se permite el préstamo actual.";
                            }
                            else
                            {

                                string sqlAnyadirDevoluciones = "INSERT INTO Toma_Prestado (Fecha_Prestamo, Fecha_Devolucion, ISBN_Libro, NumCarnet) " +
                                    "VALUES (@fechaPrestamo, @fechaDevolucion, @isbn, @numCarnet)";
                                SqlCommand anyadirDevolucion = new SqlCommand(sqlAnyadirDevoluciones, conexion);
                                anyadirDevolucion.Parameters.AddWithValue("@fechaPrestamo", fechaPrestamo);
                                anyadirDevolucion.Parameters.AddWithValue("@fechaDevolucion", fechaDevolucion);
                                anyadirDevolucion.Parameters.AddWithValue("@isbn", isbn);
                                anyadirDevolucion.Parameters.AddWithValue("@numCarnet", numCarnet);
                                anyadirDevolucion.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errores = ex.ToString();
                throw;
            }
        }

        public void BorrarLibro(string isbnLibro, out string errores)
        {
            errores = "";
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();

                    string sqlBuscarLibro = "SELECT * FROM Libro WHERE ISBN = @isbn";
                    SqlCommand cmdBuscarLibro = new SqlCommand(sqlBuscarLibro, conexion);

                    cmdBuscarLibro.Parameters.AddWithValue("@isbn", isbnLibro);

                    SqlDataReader libro = cmdBuscarLibro.ExecuteReader();

                    if (libro.Read())
                    {
                        string sqlBuscarPrestamos = "SELECT * FROM Toma_Prestado WHERE ISBN_Libro = @isbn";
                        SqlCommand cmdBuscarPrestamos = new SqlCommand(sqlBuscarPrestamos, conexion);

                        cmdBuscarPrestamos.Parameters.AddWithValue("@isbn", isbnLibro);

                        SqlDataReader prestamos = cmdBuscarPrestamos.ExecuteReader();

                        if (prestamos.Read())
                        {
                            errores = "El libro tiene unidades prestadas. No se ha podido borrado de la biblioteca.";
                        }
                        else
                        {
                            string sqlBorrarVaSobre = "DELETE FROM Va_Sobre WHERE ISBN_Libro = @isbn";
                            SqlCommand cmdBorrarVaSobre = new SqlCommand(sqlBorrarVaSobre, conexion);
                            cmdBorrarVaSobre.Parameters.AddWithValue("@isbn", isbnLibro);
                            cmdBorrarVaSobre.ExecuteNonQuery();

                            string sqlBorrarEscribe = "DELETE FROM Escribe WHERE ISBN_Libro = @isbn";
                            SqlCommand cmdBorrarEscribe = new SqlCommand(sqlBorrarEscribe, conexion);
                            cmdBorrarEscribe.Parameters.AddWithValue("@isbn", isbnLibro);
                            cmdBorrarEscribe.ExecuteNonQuery();

                            string sqlBorrarLibro = "DELETE FROM Libro WHERE ISBN = @isbn";
                            SqlCommand cmdBorrarLibro = new SqlCommand(sqlBorrarLibro, conexion);
                            cmdBorrarLibro.Parameters.AddWithValue("@isbn", isbnLibro);
                            cmdBorrarLibro.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        errores = "No existe un libro con ese ISBN";
                    }
                }
                catch (Exception)
                {
                    errores = "Error al intentar borrar el libro";
                    throw;
                }
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
                    string sql = "SELECT NumCarnetLector, FechaDevolucion FROM Toma_Prestado WHERE FechaDevolucion < GETDATE()";
                    SqlCommand cmdMorosos = new SqlCommand(sql, conexion);
                    SqlDataReader datos = cmdMorosos.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "No se encontraron lectores morosos.";
                    }
                    else
                    {
                        List<Prestamo> prestamos = new List<Prestamo>();

                        while (datos.Read())
                        {
                            Prestamo prestamo = new Prestamo
                            {
                                NumCarnetLector = datos["NumCarnetLector"].ToString(),
                                FechaDevolucion = Convert.ToDateTime(datos["FechaDevolucion"])
                            };
                            prestamos.Add(prestamo);
                        }

                        prestamos = prestamos.OrderBy(p => p.NumCarnetLector).ThenBy(p => p.FechaDevolucion).ToList();
                        string currentCarnet = null;
                        foreach (Prestamo prestamo in prestamos)
                        {
                            if (currentCarnet != prestamo.NumCarnetLector)
                            {
                                currentCarnet = prestamo.NumCarnetLector;
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    errores = "Error al buscar los lectores morosos: " + exc;
                }
                return lista;
            }
        }

    }
}
