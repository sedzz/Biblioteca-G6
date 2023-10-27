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
                catch (Exception e)
                {
                    errores = "Ocurrió un error al buscar libros: " + e.Message;
                }
            }

            return null;

        }


        public void BuscarLibroPorISBN(string isbn, out string errores)
        {
            errores = "";


            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = $"SELECT * FROM Libro WHERE Libro.Isbn = {isbn}";
                    SqlCommand cmdLibro = new SqlCommand(sql, conexion);
                    SqlDataReader datos = cmdLibro.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "no hay libro con ese isbn";
                    }

                }
                catch (Exception e)
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















