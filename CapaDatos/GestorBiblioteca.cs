﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CapaDatos
{


    /// <summary>
    /// Esta clase tiene los métodos necesarios para gestionar la biblioteca. Son los siguientes métodos:
    ///     - AñadirLibro
    ///     - ComprobarExistenciaCategoria
    ///     - ComprobarExistenciaAutor
    ///     - Prestamo
    ///     - BorrarLibro
    ///     - Morosos
    ///     - AñadirLector
    /// Todos estos métodos tienen las comprobaciones pertinentes de los datos recibidos, y se conectan a la base de datos para realizar las operaciones.
    /// </summary>
    public class GestorBiblioteca
    {
      // TODO  const string cadConexion = "Data Source=DESKTOP-T5I655L\\SEBASERVER; Initial Catalog=BibliotecaG6; Integrated Security=SSPI; MultipleActiveResultSets=true";

        const string cadConexion = "Data Source =.; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";
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
                    foreach (var categoria in categorias) // todo No hace nada con estos foreach (tengan errores, devuelvan true o false,...) ¡¡¡la bool tiene el valor del último autor!!!!
                    {
                        autoresCategoriasExistentes = comprobarExistenciaCategoria(categoria.Id, out errores);
                    }
                    foreach (var autor in autores)
                    {
                        autoresCategoriasExistentes = comprobarExistenciaAutor(autor.Id, out errores);
                    }
                    //Sale de la función sin añadir el libro si hay autores o categorías inexistentes en la base de datos.
                    if (!autoresCategoriasExistentes)
                    {
                        errores = "Hay autores o categorías que no existen en la base de datos. Añade primero los autores o libros.";
                        return;
                    }

                    //Inserto el libro en la base de datos, habiendo comprobado los datos recibidos.

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


                    //Inserto los registros en la tabla Libro-Categoría, por cada categoría recibida, habiendo comprobado ya que existen en la base de datos.
                    string sqlAnyadirVaSobre = "INSERT INTO Va_Sobre (ISBN_Libro, Id_Categoria) VALUES (@isbn, @idCategoria)";
                    SqlCommand cmdInsertarVaSobre = new SqlCommand(sqlAnyadirVaSobre, conexion);


                    foreach (var categoria in categorias)
                    {
                        cmdInsertarVaSobre.Parameters.Clear();
                        cmdInsertarVaSobre.Parameters.AddWithValue("@isbn", isbn);
                        cmdInsertarVaSobre.Parameters.AddWithValue("@idCategoria", categoria.Id);
                        cmdInsertarVaSobre.ExecuteNonQuery();
                    }

                    //Inserto los registros en la tabla Libro-Autor, por cada autor recibido, habiendo comprobado ya que existen en la base de datos.
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



        /// <summary>
        /// Método que hace nuevos préstamos, insertando los registros en la base de datos.
        /// Comprueba que el libro con ese isbn exista, comprueba que el libro sea prestable, y no de solo consulta. Comprueba que el usuario no tenga préstamos morosos. Y comprueba que hayan unidades disponibles del libro.
        /// </summary>
        /// <param name="fechaPrestamo"></param>
        /// <param name="fechaDevolucion"></param>
        /// <param name="isbn"></param>
        /// <param name="numCarnet"></param>
        /// <param name="errores"></param>
        public void Prestamo(DateTime fechaPrestamo, DateTime fechaDevolucion, string isbn, string numCarnet, out string errores)
        {
            errores = "";
            try
            {
                // todo Varias lecturas al mismo libro? Solo 1 y obtener todos los datos del libro
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
                                // TODO Debe controlar que no existe ese préstamo (pero bien hecho) y si no queréis dejar que un lector se lleve 2 unidades diferentes, no sería como lo hacéis

                                string sqlAnyadirDevoluciones = "INSERT INTO Toma_Prestado (Fecha_Prestamo, Fecha_Devolucion, ISBN_Libro, NumCarnet) " +
                                    "VALUES (@fechaPrestamo, @fechaDevolucion, @isbn, @numCarnet)";
                                SqlCommand anyadirDevolucion = new SqlCommand(sqlAnyadirDevoluciones, conexion);
                                anyadirDevolucion.Parameters.AddWithValue("@fechaPrestamo", fechaPrestamo);
                                anyadirDevolucion.Parameters.AddWithValue("@fechaDevolucion", fechaDevolucion);
                                anyadirDevolucion.Parameters.AddWithValue("@isbn", isbn);
                                anyadirDevolucion.Parameters.AddWithValue("@numCarnet", numCarnet);
                                anyadirDevolucion.ExecuteNonQuery();

                                string verificarUnidades = "SELECT Unidades FROM Libro WHERE ISBN = @isbn";
                                SqlCommand verificarUnidadesCmd = new SqlCommand(verificarUnidades, conexion);
                                verificarUnidadesCmd.Parameters.AddWithValue("@isbn", isbn);
                                int unidades = (int)verificarUnidadesCmd.ExecuteScalar();

                                if ((unidades -1) >= 0) // todo Las unidades nunca debían cambiar, debía controlar que unidades > cantidad de veces prestado
                                {
                                    string sqlActualizarUnidadesLibro = "UPDATE Libro SET Unidades = Unidades - 1 WHERE ISBN = @isbn";
                                    SqlCommand actualizarUnidadesLibro = new SqlCommand(sqlActualizarUnidadesLibro, conexion);
                                    actualizarUnidadesLibro.Parameters.AddWithValue("@isbn", isbn);
                                    actualizarUnidadesLibro.ExecuteNonQuery();
                                }
                                else
                                {
                                    errores = "No quedan mas unidades de este libro";
                                }

                                
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                errores = $"Un mismo lector no puedo pedir prestado el mismo libro"; // todo Podría ser por otro error diferente e incluso si el lector intenta coger el mismo libro otro día le dejaría
            }catch (Exception ex)
            {
                errores = ex.ToString();
            }
        }



        /// <summary>
        /// Método que permite borrar libros de la base de datos, recibiendo su ISBN. Comprueba que el libro exista, y que no tenga unidades prestadas.
        /// Borra los registros de la tabla Autor-libro, de la tabla Libro-Categoría y de la tabla libro.
        /// </summary>
        /// <param name="isbnLibro"></param>
        /// <param name="errores"></param>
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



        /// <summary>
        /// Este método obtiene los morosos de la base de datos, y los devuelve en forma de lista.
        /// </summary>
        /// <param name="errores"></param>
        /// <returns></returns>
        public List<Lector> Morosos(out string errores)
        {
            errores = "";
            List<Lector> lista = new List<Lector>();

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT DISTINCT NumCarnet FROM Toma_Prestado WHERE Fecha_Devolucion < GETDATE()";
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
                            Lector lector = new Lector
                            {
                                NumCarnet = datos["NumCarnet"].ToString()
                            };
                            lista.Add(lector);
                        }
                    }
                }
                catch (Exception exc)
                {
                    errores = "Error al buscar los lectores morosos: " + exc.Message;
                }
            }

            return lista;
        }

        public Boolean Devolucion(List<Libro> librosDevolucion, out string error)
        {
            error = "";
            // todo No controla que sea del lector en concreto, aumenta las unidades del libro y no saca nada en fichero de datos
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    List<Prestamo> listaLibrosDevolucion = new List<Prestamo>();
                    foreach (var libro in librosDevolucion)
                    {
                        string consultaPrestamoPorISbn = $"SELECT * FROM Toma_Prestado WHERE ISBN_libro = '{libro.Isbn}';";
                        SqlCommand PrestamoPorISbn = new SqlCommand(consultaPrestamoPorISbn, conexion);
                        SqlDataReader resultadoPrestamoPorISbn = PrestamoPorISbn.ExecuteReader();

                        while (resultadoPrestamoPorISbn.Read())
                        {
                            DateTime fechaPrestamo = DateTime.Parse(resultadoPrestamoPorISbn["Fecha_Prestamo"].ToString());
                            DateTime fechaDevolucion = DateTime.Parse(resultadoPrestamoPorISbn["Fecha_Devolucion"].ToString());

                            listaLibrosDevolucion.Add(new Prestamo(fechaPrestamo, fechaDevolucion, resultadoPrestamoPorISbn["ISBN_Libro"].ToString()));
                        }
                    }

                    foreach (var libroParaDevolver in listaLibrosDevolucion)
                    {
                        string consultaEliminarLibroPrestado = $"DELETE FROM Toma_Prestado WHERE ISBN_libro = @isbn AND Fecha_Prestamo = @Fecha_Prestamo AND Fecha_Devolucion = @Fecha_Devolucion";
                        SqlCommand EliminarLibroPrestado = new SqlCommand(consultaEliminarLibroPrestado, conexion);

                        EliminarLibroPrestado.Parameters.AddWithValue("@isbn", libroParaDevolver.ISBN_Libro);
                        EliminarLibroPrestado.Parameters.AddWithValue("@Fecha_Devolucion", libroParaDevolver.FechaDevolucion);
                        EliminarLibroPrestado.Parameters.AddWithValue("@Fecha_Prestamo", libroParaDevolver.FechaPrestamo);

                        int numDeFilasAceptadas = EliminarLibroPrestado.ExecuteNonQuery();

                        string sqlActualizarUnidadesLibro = "UPDATE Libro SET Unidades = Unidades + 1 WHERE ISBN = @isbn";
                        SqlCommand actualizarUnidadesLibro = new SqlCommand(sqlActualizarUnidadesLibro, conexion);
                        actualizarUnidadesLibro.Parameters.AddWithValue("@isbn", libroParaDevolver.ISBN_Libro);
                        actualizarUnidadesLibro.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception exc)
                {
                    error = "Error al eliminar las devoluciones: " + exc;
                    return false;
                }
            }
        }
        public List<Prestamo> LibrosPrestados(String numCarnet, out String error) // todo Nombre nada significativo
        {
             error = "";
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                    List<Prestamo> libros = new List<Prestamo>();
                try
                {
                    conexion.Open();

                    string consultaLibrosDeUnLector = $"SELECT * FROM Toma_Prestado WHERE NumCarnet = '{numCarnet}';"; // todo Se debe hacer con parámetro
                    SqlCommand librosDeUnLector = new SqlCommand(consultaLibrosDeUnLector, conexion);

                    SqlDataReader resultadoLibroDeUnLector = librosDeUnLector.ExecuteReader();
                    

                    while (resultadoLibroDeUnLector.Read())
                    {
                        DateTime fechaPrestamo = DateTime.Parse(resultadoLibroDeUnLector["Fecha_Prestamo"].ToString());
                        DateTime fechaDevolucion = DateTime.Parse(resultadoLibroDeUnLector["Fecha_Devolucion"].ToString());

                        libros.Add(new Prestamo(fechaPrestamo, fechaDevolucion, resultadoLibroDeUnLector["ISBN_Libro"].ToString()));
                    }
                   
                }
                catch (Exception exc)
                {
                    error = "Error al buscar libros prestados: "+exc.Message;
                  
                } 
                return libros;
            }
        }

        public Libro BuscarTituloLibroPorISBN(String isbn)
        {
            String errores = "";
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {

                try
                {
                    conexion.Open();

                    string consultaLibrosPorISBN = $"SELECT * FROM Libro WHERE ISBN = '{isbn}';";
                    SqlCommand libroPorISBN = new SqlCommand(consultaLibrosPorISBN, conexion);

                    SqlDataReader resultadolibroPorISBN = libroPorISBN.ExecuteReader();

                    while (resultadolibroPorISBN.Read())
                    {
                        Libro libro = new Libro(resultadolibroPorISBN["ISBN"].ToString(), resultadolibroPorISBN["Titulo"].ToString());

                        return libro;
                    }
                    return null;
                }
                catch (Exception exc)
                {
                    errores = "No se encontro ningun libro: "+exc.Message;
                    throw;

                }
            }


        }


        /// <summary>
        /// Método que permite añadir un nuevo lector a la base de datos. Comprueba que los datos recibidos no estén vacíos.
        /// El número de carnet se genera automáticamente al añadirlo a la base de datos.
        /// </summary>
        /// <param name="errores"></param>
        /// <param name="nombre"></param>
        /// <param name="contraseña"></param>
        /// <param name="telefono"></param>
        /// <param name="gmail"></param>
        public void AñadirLector(out string errores, string nombre, string contraseña, string telefono, string gmail)
        {
            // todo: Error de ejecución
            errores = "";
            if (String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(contraseña) || String.IsNullOrWhiteSpace(telefono) || String.IsNullOrWhiteSpace(gmail))
            {
                errores = "No se pueden dejar campos vacíos";
                return;
            }

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();

                    string sqlAnyadirLibro = "INSERT INTO Lector (Nombre, Contrasena, Telefono, Email) " +
                        "VALUES (@nombre, @contraseña, @telefono, @email)";
                    SqlCommand cmdInsertarLibro = new SqlCommand(sqlAnyadirLibro, conexion);

                    cmdInsertarLibro.Parameters.AddWithValue("@nombre", nombre);
                    cmdInsertarLibro.Parameters.AddWithValue("@contraseña", contraseña);
                    cmdInsertarLibro.Parameters.AddWithValue("@telefono", telefono);
                    cmdInsertarLibro.Parameters.AddWithValue("@email", gmail);

                    cmdInsertarLibro.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    errores = "Error al conectar con la base de datos: " + e;
                    return;
                }
                
            }


        }

        public void AñadirAutor(string nombre, out string errores)
        {
            // todo Puede haber varios con el mismo nombre!!!!
            errores = "";
            if (String.IsNullOrWhiteSpace(nombre))
            {
                errores = "No se pueden dejar campos vacíos";
                return;
            }

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();

                    string sqlAnyadirAutor = "INSERT INTO Autor (Nombre) " +
                        "VALUES (@nombre)";
                    SqlCommand cmdInsertarAutor = new SqlCommand(sqlAnyadirAutor, conexion);

                    cmdInsertarAutor.Parameters.AddWithValue("@nombre", nombre);

                    cmdInsertarAutor.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    errores = "Error al conectar con la base de datos" + e;
                    return;
                }

            }


        }


    }
}
