using Entidades;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Consultas
    {
        const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";


        public void BuscarLibroPorPorcionTitulo(string porcionTitulo, out string errores)
        {
            errores = "";


            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Libro WHERE Libro.Titulo LIKE *" + porcionTitulo + "*";
                    SqlCommand cmdLibro = new SqlCommand(sql, conexion);

                    SqlDataReader datos = cmdLibro.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "no hay libros existentes";
                    }

                }
                catch (Exception e)
                {

                    throw;
                }
            }


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
    }
}

   

    //public Categoria BuscarCategoriaPorId(int id, out string errores)
    //{
    //    errores = "";
    //    using (SqlConnection conexion = new SqlConnection(cadConexion))
    //    {
    //        try
    //        {
    //            conexion.Open();
    //            string sql = "SELECT * FROM Categoria WHERE Categoria.ID = " + id;
    //            SqlCommand cmdCategoriaID = new SqlCommand(sql, conexion);

    //            SqlDataReader datos = cmdCategoriaNombre.ExecuteReader();

    //            if (!datos.HasRows)
    //            {
    //                errores = "No hay categoría con ese ID.";
    //            }
    //            else
    //            {
    //                descripcion = datos["Descripcion"].toString();
    //                Categoria cat = new Categoria(id, descripcion);
    //                return cat;
    //            }

    //        }
    //        catch (Exception e)
    //        {
    //            throw;
    //        }
    //    }

 








