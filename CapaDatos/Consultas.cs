using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Consultas
    {
        const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";


        public List<Libro> BuscarLibroPorPorcionTitulo(string porcionTitulo, out string errores)
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
                catch (Exception)
                {
                    errores = "Ocurrió un error al buscar libros: " + e.Message;
                }
            }

            return null;

        }
        //De autor@, lector@ por identificador 
        public Autor BuscarAutorPorID(int id)
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
                                    return autor;
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
        public Lector BuscarLectorPorID(string NumCarnet)
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
                                        Gmail = datos["Gmail"].ToString()
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

        public Libro BuscarLibroPorISBN(string isbn)
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


        //De lector@s, autor @s por trozo de nombre
        public void BuscarLibroPorISBN(string isbn, out string errores)
        {
            errores = "";


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
                            if (!datos.HasRows)
                            {
                                errores = "No hay libro con ese ISBN.";
                            }

                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        public Categoria BuscarCategoriaPorId(int id, out string errores)
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
                catch (Exception e)
                {
                    throw;
                }
            }
            return null;

        }
    }
}















