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
        const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";  
        DatosBiblioteca biblioteca = new DatosBiblioteca("4V","San Jorge","./logo.png");
        public void AñadirLibro(out string errores, string isbn, string titulo, string editorial, List<Autor> autores, string sinopsis, string caratula, List<Categoria> categorias, int unidadesExistentes, string disponibilidad, List<Prestamo> prestamos) {
            errores = "";
           // Libro L = new Libro(isbn, titulo, editorial, autores, sinopsis, caratula, categorias, unidadesExistentes, disponibilidad, prestamos);
;            using (SqlConnection conexion = new SqlConnection(cadConexion))
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

                    //while (datos.Read())
                    //{
                    //    String isbn = datos["ISBN"].ToString();
                    //    String titulo = datos["Titulo"].ToString();
                    //    String editorial = datos["Editorial"].ToString();
                    //    Libro libro = new Libro();
                    //    List<Autor> autores = new List<Autor>();
                    //    foreach (Autor autor in libro.Autores)
                    //    {
                    //        autores.Add(autor);
                    //    }
                    //    String sinopsis = datos["Sinopsis"].ToString();
                    //    String caratula = datos["Caratula"].ToString();
                    //    List<Categoria> categorias = new List<Categoria>();
                        
                                            
                       
                    //    String unidades = datos["Unidades"].ToString();
                    //    String disponibilidad = datos["Disponibilidad"].ToString();                       
                    //}





                }
                catch (Exception)
                {

                    throw;
                }
            }

        }


    }
}

