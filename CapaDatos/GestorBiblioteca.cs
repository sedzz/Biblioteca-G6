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
        const string cadConexion = "Data Source = localhost; Initial Catalog = BIBLIOTECA; Integrated Security = SSPI; MultipleActiveResultSets=true";  
        DatosBiblioteca biblioteca = new DatosBiblioteca("4V","San Jorge","./logo.png");
        private void AñadirLibro(out string errores) {
            errores = "";
            

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Libro";
                    SqlCommand cmdLibro = new SqlCommand(sql, conexion);
                    SqlDataReader datos = cmdLibro.ExecuteReader();

                    if (!datos.HasRows)
                    {
                        errores = "no hay libros existentes";
                    }

                    while (datos.Read())
                    {
                        String isbn = datos["ISBN"].ToString();
                        String titulo = datos["Titulo"].ToString();
                        String editorial = datos["Editorial"].ToString();
                        Libro libro = new Libro();
                        List<Autor> autores = new List<Autor>();
                        foreach (Autor autor in libro.Autores)
                        {
                            autores.Add(autor);
                        }
                        String sinopsis = datos["Sinopsis"].ToString();
                        String caratula = datos["Caratula"].ToString(); 
                        
                        foreach (Categoria categoria in libro.Categorias)
                        {
                            libro.Categorias.Add(categoria);
                        }
                        String unidades = datos["Unidades"].ToString();
                        String disponibilidad = datos["Disponibilidad"].ToString();                       
                        biblioteca.Libros.Add(new Libro(isbn, titulo, editorial,autor,sinopsis, caratula, categorias, unidades,disponibilidad));
                    }





                }
                catch (Exception)
                {

                    throw;
                }
            }

        }


    }
}
