using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos
{
    public class GestorBiblioteca
    {
        const string cadConexion = "Data Source=localhost; Initial Catalog=BibliotecaG6; Integrated Security=SSPI; MultipleActiveResultSets=true";
        DatosBiblioteca biblioteca = new DatosBiblioteca("4V", "San Jorge", "./logo.png");


        /// <summary>
        /// Método que recibe los datos de un nuevo libro para añadirlo a la base de datos.
        /// Comprueba que hayan autores y categorías asociados al libro, y que existan en la base de datos, devolviendo un mensaje de error si no es así. Comprueba que los datos recibidos no estén vacíos.
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="titulo"></param>
        /// <param name="editorial"></param>
        /// <param name="sinopsis"></param>
        /// <param name="caratula"></param>
        /// <param name="unidadesExistentes"></param>
        /// <param name="disponibilidad"></param>
        /// <param name="autores"></param>
        /// <param name="categorias"></param>
        /// <param name="errores"></param>
        public void AñadirLibro(string isbn, string titulo, string editorial, string sinopsis, string caratula, int unidadesExistentes, string disponibilidad, List<Autor> autores, List<Categoria> categorias, out string errores)
        {
            errores = "";


            //Comprobamos que el libro tenga autores y categorías asociados.
            if (autores.Count == 0 || categorias.Count == 0)
            {
                errores = "No se puede añadir un libro sin autores o sin categorías";
                return;
            }
            //Comprobamos que no queden campos vacíos.
            if (String.IsNullOrWhiteSpace(isbn) || String.IsNullOrWhiteSpace(titulo) || String.IsNullOrWhiteSpace(editorial) || String.IsNullOrWhiteSpace(sinopsis) || String.IsNullOrWhiteSpace(caratula) || String.IsNullOrWhiteSpace(disponibilidad))
            {
                errores = "No se pueden dejar campos vacíos";
                return;
            }
            //Comprueba que haya un número de unidades positivo.
            if (unidadesExistentes <= 0)
            {
                errores = "El número de unidades existentes debe ser mayor que 0";
                return;
            }

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
               
                    //Comprueba que los autores y categorías existan en la base de datos, utilizando 2 métodos auxiliares.
                    bool autoresCategoriasExistentes = true;
                    foreach (var categoria in categorias)
                    {
                        autoresCategoriasExistentes = comprobarExistenciaCategoria(categoria.Id, out errores);
                    }
                    foreach (var autor in autores)
                    {
                        autoresCategoriasExistentes = comprobarExistenciaAutor(autor.Id, out errores);
                    }
                    //Sale de la función sin añadir el libro, si hay autores o categorías inexistentes en la base de datos.
                    if (!autoresCategoriasExistentes)
                    {
                        errores = "Hay autores o categorías que no existen en la base de datos. Añade primero los autores o libros.";
                        return;
                    }



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
                        cmdInsertarVaSobre.Parameters.AddWithValue("@idCategoria", categoria.Id);
                        cmdInsertarVaSobre.ExecuteNonQuery();
                    }

                    string sqlAnyadirEscribe = "INSERT INTO Escribe (ISBN_Libro, Id_Autor) VALUES (@isbn, @idAutor)";
                    SqlCommand cmdInsertarEscribe = new SqlCommand(sqlAnyadirEscribe, conexion);

                    foreach (var autor in autores)
                    {
                        cmdInsertarEscribe.Parameters.Clear();
                        cmdInsertarEscribe.Parameters.AddWithValue("@isbn", isbn);
                        cmdInsertarEscribe.Parameters.AddWithValue("@idAutor", autor.Id);
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



        /// <summary>
        /// Este método comprueba contra la base de datos que exista una categoría con el ID recibido.
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <param name="errores"></param>
        /// <returns></returns>
        private bool comprobarExistenciaCategoria(int idCategoria, out String errores)
        {
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sqlVerificarExistenciaCategoria = "SELECT ID FROM Categoria WHERE ID = @idCategoria";
                    SqlCommand verificarExistenciaCategoria = new SqlCommand(sqlVerificarExistenciaCategoria, conexion);
                    verificarExistenciaCategoria.Parameters.AddWithValue("@idCategoria", idCategoria);
                    var categoriaExistente = verificarExistenciaCategoria.ExecuteScalar();

                    if (categoriaExistente == null)
                    {
                        errores = "La categoría seleccionada no existe";
                        return false;
                    }
                    else
                    {
                        errores = "";
                        return true;
                    }
                }
                catch (Exception e)
                {
                    errores = "Error al conectar con la base de datos" + e;
                    return false;
                }
            }
        }



        /// <summary>
        /// Este método comprueba que exista un autor con el ID recibido, contra la base de datos.
        /// </summary>
        /// <param name="idAutor"></param>
        /// <param name="errores"></param>
        /// <returns></returns>
        private bool comprobarExistenciaAutor(int idAutor, out String errores)
        {
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sqlVerificarExistenciaAutor = "SELECT ID FROM Autor WHERE ID = @idAutor";
                    SqlCommand verificarExistenciaAutor = new SqlCommand(sqlVerificarExistenciaAutor, conexion);
                    verificarExistenciaAutor.Parameters.AddWithValue("@idAutor", idAutor);
                    var autorExistente = verificarExistenciaAutor.ExecuteScalar();

                    if (autorExistente == null)
                    {
                        errores = "El autor buscado no existe";
                        return false;
                    }
                    else
                    {
                        errores = "";
                        return true;
                    }
                }
                catch (Exception e)
                {
                    errores = "Error al conectar con la base de datos" + e;
                    return false;
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
                            errores = "El libro tiene unidades prestadas. No se ha borrado de la biblioteca.";
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
