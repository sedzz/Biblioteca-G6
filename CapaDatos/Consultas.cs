using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{

     /// <summary>
     /// Esta clase contiene consultas contra la base de datos, para obtener datos de libros, autores, lectores, etc.
     /// </summary>
     public static class Consultas
    {
        const string cadConexion = "Data Source = DESKTOP-EGM64RC\\MSQLSERVER; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";


         /// <summary>
         /// Este método permite obtener todos los libros de la base de datos cuyo nombre contenga la porción de título proporcionada. Devuelve una lista de libros.
         /// </summary>
         /// <param name="porcionTitulo"></param>
         /// <param name="errores"></param>
         /// <returns></returns>
         public static List<Libro> BuscarLibroPorPorcionTitulo(string porcionTitulo, out string errores)
        {
            errores = "";
            List<Libro> resultado = new List<Libro>();
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Libro WHERE Libro.Titulo LIKE @porcionTitulo";
                    SqlCommand cmdLibro = new SqlCommand(sql, conexion);
                    cmdLibro.Parameters.AddWithValue("@porcionTitulo", "%" + porcionTitulo + "%");

                    SqlDataReader datos = cmdLibro.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "No se encontraron libros que coincidan con la porción del título proporcionada.";
                    }
                    else
                    {
                        while (datos.Read())
                        {
                            string isbn = datos["Isbn"].ToString();
                            string titulo = datos["Titulo"].ToString();
                            string editorial = datos["Editorial"].ToString();
                            string sinopsis = datos["Sinopsis"].ToString();
                            string caratula = datos["Caratula"].ToString();
                            int unidades = (int)datos["unidades"];
                            string disponibilidad = datos["disponibilidad"].ToString();
                            Libro libro = new Libro(isbn, titulo, editorial, sinopsis, caratula, unidades, disponibilidad);
                            resultado.Add(libro);
                        }
                        return resultado;
                    }
                }
                catch (Exception e)
                {
                    errores = "Ocurrió un error al buscar libros: " + e.Message;
                }
            }

            return null;

        }



         /// <summary>
         /// Este método obtiene todas las categorías de la base de datos y las devuelve en forma de lista de categorías.
         /// </summary>
         /// <param name="errores"></param>
         /// <returns></returns>
         public static List<Categoria> TodasLasCategorias(out string errores)
        {
            errores = "";
            List<Categoria> resultado = new List<Categoria>();
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Categoria";
                    SqlCommand cmdTodasCategorias = new SqlCommand(sql, conexion);

                    SqlDataReader datos = cmdTodasCategorias.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "No se encontraron libros que coincidan con la porción del título proporcionada.";
                    }
                    else
                    {
                        while (datos.Read())
                        {
                            int id = (int)datos["id"];
                            string descripcion = datos["Descripcion"].ToString();
                            Categoria cat = new Categoria(id, descripcion);
                            resultado.Add(cat);
                        }
                        return resultado;
                    }
                }
                catch (Exception e)
                {
                    errores = "Ocurrió un error al buscar libros: " + e.Message;
                }
            }

            return null;

        }




         
         /// <summary>
         /// Recibiendo un id de autor, devuelve dicho autor con todos sus datos, o null si no se encuentra.
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
         public static Autor BuscarAutorPorID(int id)
        {
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Autor WHERE Autor.ID = @ID";
                    using (SqlCommand cmdAutor = new SqlCommand(sql, conexion))
                    {
                        cmdAutor.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader datos = cmdAutor.ExecuteReader())
                        {
                            if (datos.HasRows)
                            {
                                // Crear un objeto Libro y asignar valores desde la base de datos
                                if (datos.Read())
                                {
                                    Autor autor = new Autor
                                    {
                                        Id = (int)datos["ID"],
                                        Nombre = datos["Nombre"].ToString()
                                    };
                                }
                            }
                        }
                    }

                    // Si no se encuentra ningún libro con el ISBN dado, puedes devolver null o lanzar una excepción personalizada.
                    return null;
                }
                catch (Exception)
                {
                    // Manejar la excepción aquí o lanzarla nuevamente si es necesario.
                    throw;
                }
            }
        }



        /// <summary>
        /// Recibiendo una porción de nombre, devuelve una lista de autores cuyo nombre contenga dicha porción. Si no hay, devuelve null.
        /// </summary>
        /// <param name="porcionNombre"></param>
        /// <param name="errores"></param>
        /// <returns></returns>
        public static List<Autor> BuscarAutorPorPorcionNombre(string porcionNombre, out string errores)
        {
            errores = "";
            List<Autor> resultado = new List<Autor>();
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Autor WHERE Autor.Nombre LIKE @porcionNombre";
                    SqlCommand cmdAutor = new SqlCommand(sql, conexion);
                    cmdAutor.Parameters.AddWithValue("@porcionNombre", "%" + porcionNombre + "%");

                    SqlDataReader datos = cmdAutor.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "No se encontraron autores que coincidan con la porción del nombre proporcionada.";
                    }
                    else
                    {
                        while (datos.Read())
                        {
                            int Id = (int)datos["Id"];
                            string Nombre = datos["Nombre"].ToString();
                            Autor autor = new Autor(Id, Nombre);
                            resultado.Add(autor);
                        }
                        return resultado;
                    }
                }
                catch (Exception e)
                {
                    errores = "Ocurrió un error al buscar autores: " + e.Message;
                }
            }

            return null;

        }


         /// <summary>
         /// Devuelve una lista de lectores cuyo nombre contenga la porción de nombre proporcionada. Si no hay, devuelve null.
         /// </summary>
         /// <param name="porcionNombre"></param>
         /// <param name="errores"></param>
         /// <returns></returns>
         public static List<Lector> BuscarLectorPorPorcionNombre(string porcionNombre, out string errores)
        {
            errores = "";
            List<Lector> resultado = new List<Lector>();
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Lector WHERE Lector.Nombre LIKE @porcionNombre";
                    SqlCommand cmdLector = new SqlCommand(sql, conexion);
                    cmdLector.Parameters.AddWithValue("@porcionNombre", "%" + porcionNombre + "%");

                    SqlDataReader datos = cmdLector.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "No se encontraron lectores que coincidan con la porción del nombre proporcionada.";
                    }
                    else
                    {
                        while (datos.Read())
                        {
                            string NumCarnet = datos["NumCarnet"].ToString();
                            string Nombre = datos["Nombre"].ToString();
                            string Contraseña = datos["Contrasena"].ToString();
                            string Telefono = datos["Telefono"].ToString();
                            string Gmail = datos["Email"].ToString();

                            Lector lector = new Lector(NumCarnet, Nombre,Contraseña,Telefono,Gmail);
                            resultado.Add(lector);
                        }

                        return resultado;
                    }
                }
                catch (Exception e)
                {
                    errores = "Ocurrió un error al buscar lectores: " + e.Message;
                }
            }

            return null;

        }



         /// <summary>
         /// Recibiendo un número de carné, devuelve el lector con dicho carné, o null si no se encuentra.
         /// </summary>
         /// <param name="NumCarnet"></param>
         /// <returns></returns>
         public static Lector BuscarLectorPorID(string NumCarnet, out string errores)
        {
            errores = "";
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Lector WHERE Lector.NumCarnet = @NumCarnet";
                    using (SqlCommand cmdAutor = new SqlCommand(sql, conexion))
                    {
                        cmdAutor.Parameters.AddWithValue("@NumCarnet", NumCarnet);
                        using (SqlDataReader datos = cmdAutor.ExecuteReader())
                        {
                            if (datos.HasRows)
                            {
                                if (datos.Read())
                                {
                                    Lector lector = new Lector
                                    {
                                        NumCarnet = datos["NumCarnet"].ToString(),
                                        Nombre = datos["Nombre"].ToString(),
                                        Contraseña = datos["Contrasena"].ToString(),
                                        Telefono = datos["Telefono"].ToString(),
                                        Gmail = datos["Email"].ToString()
                                    };
                                    return lector;
                                }
                            }
                        }
                    }
                    errores ="No se encontró un lector con ese número de carné.";
                    return null;
                }
                catch (Exception e)
                {
                    errores ="Ocurrió un error al buscar el lector en la base de datos"+e;
                    throw;
                }
            }
        }



         /// <summary>
         /// Recibiendo un isbn, devuelve el libro con dicho isbn, o null si no se encuentra.
         /// </summary>
         /// <param name="isbn"></param>
         /// <returns></returns>
         public static Libro BuscarLibroPorISBN(string isbn)
        {
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Libro WHERE Libro.Isbn = @isbn";
                    using (SqlCommand cmdLibro = new SqlCommand(sql, conexion))
                    {
                        cmdLibro.Parameters.AddWithValue("@isbn", isbn);
                        using (SqlDataReader datos = cmdLibro.ExecuteReader())
                        {
                            if (datos.HasRows)
                            {
                                // Crear un objeto Libro y asignar valores desde la base de datos
                                if (datos.Read())
                                {
                                    Libro libro = new Libro
                                    {
                                        Isbn = datos["Isbn"].ToString(),
                                        Titulo = datos["Titulo"].ToString(),
                                        Editorial = datos["Editorial"].ToString(),
                                        Sinopsis = datos["Sinopsis"].ToString(),
                                        Caratula = datos["Caratula"].ToString(),
                                        UnidadesExistentes = (int)datos["Unidades"],
                                        Disponibilidad = datos["Disponibilidad"].ToString()
                                    };
                                    return libro;
                                }
                            }
                        }
                    }

                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        /// <summary>
        /// Este método devuelve una Categoria, cuyo ID coincida con el proporcionado. Si no hay, devuelve null.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errores"></param>
        /// <returns></returns>
        public static Categoria BuscarCategoriaPorId(int id, out string errores)
        {
            errores = "";
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Categoria WHERE Categoria.ID = @id";
                    SqlCommand cmdCategoriaID = new SqlCommand(sql, conexion);
                    cmdCategoriaID.Parameters.AddWithValue("@id", id);

                    SqlDataReader datos = cmdCategoriaID.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "No hay categoría con ese ID.";
                    }
                    else
                    {
                        string descripcion = datos["Descripcion"].ToString();
                        Categoria cat = new Categoria(id, descripcion);
                        return cat;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;

        }


         /// <summary>
         /// Este método, recibiendo un nombre de categoría, devuelve la categoría con dicho nombre, o null si no se encuentra.
         /// </summary>
         /// <param name="nombre"></param>
         /// <param name="errores"></param>
         /// <returns></returns>
         public static Categoria BuscarCategoriaPorNombre(string nombre, out string errores)
        {
            errores = "";
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Categoria WHERE Categoria.Descripcion = @nombre";
                    SqlCommand cmdCategoriaNombre = new SqlCommand(sql, conexion);
                    cmdCategoriaNombre.Parameters.AddWithValue("@Descripcion", nombre);

                    SqlDataReader datos = cmdCategoriaNombre.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "No hay categoría con ese Descripcion.";
                    }
                    else
                    {
                        int id = (int)datos["ID"];
                        Categoria cat = new Categoria(id, nombre);
                        return cat;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;

        }


        /// <summary>
        /// Recibiendo un número de carnet, devuelve los prestamos que tiene dicho lector, o null si no tiene ninguno, o no existe el lector con ese número de carnet.
        /// </summary>
        /// <param name="numCarnet"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static List<Prestamo> DevolverListaDeLibrosPrestados(string numCarnet, out string error)
        {
            error = "";

            const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {

                try
                {
                    conexion.Open();
                    string sqlanyadirLibro = $"SELECT COUNT() FROM Lector WHERE NumCarnet = '{numCarnet}';";
                    SqlCommand existeUnLector = new SqlCommand(sqlanyadirLibro, conexion);

                    SqlDataReader resultadoExisteLector = existeUnLector.ExecuteReader();

                    if (resultadoExisteLector.FieldCount != -1)
                    {
                        List<Prestamo> listaLibrosPrestados = new List<Prestamo>();
                        string consultaLibrosDeUnLector = $"SELECT * FROM Toma_Prestado WHERE NumCarnet = '{numCarnet}';";
                        SqlCommand librosDeUnLector = new SqlCommand(consultaLibrosDeUnLector, conexion);

                        SqlDataReader resultadoLibroDeUnLector = librosDeUnLector.ExecuteReader();

                        if (!resultadoLibroDeUnLector.HasRows)
                        {
                            error = "No se han encontrado libros prestados al lector";
                        }
                        else
                        {

                            while (resultadoLibroDeUnLector.Read())
                            {
                                string isbnLibro = (string)resultadoLibroDeUnLector["ISBN_Libro"];
                                DateTime fecha_Prestamo = (DateTime)resultadoLibroDeUnLector["Fecha_Prestamo"];
                                DateTime fecha_Devolucion = (DateTime)resultadoLibroDeUnLector["Fecha_Devolucion"];
                                string numCarnetPrestamo = (string)resultadoLibroDeUnLector["NumCarnet"];
                                Prestamo libroPrestado = new Prestamo(isbnLibro, numCarnetPrestamo, fecha_Prestamo, fecha_Devolucion);
                                listaLibrosPrestados.Add(libroPrestado);
                            }
                            return listaLibrosPrestados;
                        }
                    }
                    else
                    {
                        error = $"No se ha encontrado un lector";

                    }
                }
                catch (Exception)
                {
                    error = "Error al agregar el libro";
                    throw;
                }
                return null;
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="errores"></param>
        /// <returns></returns>
        public static List<Lector> ObtenerTodosLosLectores(out string errores) 
        {
            errores = "";
            
            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sqlTodosLosLectores = "SELECT * FROM Lector";
                    SqlCommand cmdTodosLosLectores = new SqlCommand(sqlTodosLosLectores, conexion);

                    SqlDataReader todosLosLectores = cmdTodosLosLectores.ExecuteReader();

                    if (!todosLosLectores.HasRows)
                    {
                        errores = "No se encontraron lectores";
                        return null;
                    }
                    else
                    {
                        List<Lector> listaLectores = new List<Lector>();
                        while (todosLosLectores.Read())
                        {
                            string NumCarnet = todosLosLectores["NumCarnet"].ToString();
                            string Nombre = todosLosLectores["Nombre"].ToString();
                            string Contraseña = todosLosLectores["Contrasena"].ToString();
                            string Telefono = todosLosLectores["Telefono"].ToString();
                            string Email = todosLosLectores["Email"].ToString();

                            Lector lector = new Lector(NumCarnet, Nombre, Contraseña, Telefono, Email);
                            listaLectores.Add(lector);
                        }
                        return listaLectores;
                    }
                }
                catch (Exception e)
                {
                    errores = "Ocurrió un error al conectarse con la base de datos para buscar lectores: " + e.Message;
                }
                return null;
            }   

        }


     }
}















