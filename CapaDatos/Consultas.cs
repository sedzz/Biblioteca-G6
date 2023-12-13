using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
     public static class Consultas
    {
        const string cadConexion = "Data Source = DESKTOP-T5I655L\\SEBASERVER; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";


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




        //De autor@, lector@ por identificador 
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
                            string Gmail = datos["Gmail"].ToString();

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
         public static Lector BuscarLectorPorID(string NumCarnet)
        {
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
                                // Crear un objeto Libro y asignar valores desde la base de datos
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
    }
}















