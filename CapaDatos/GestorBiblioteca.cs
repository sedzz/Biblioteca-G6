using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GestorBiblioteca
    {
        const string cadConexion = "Data Source = localhost; Initial Catalog = BIBLIOTECA; Integrated Security = SSPI; MultipleActiveResultSets=true";  

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
                        String sinopsis = datos["Sinopsis"].ToString();
                        String caratula = datos["Caratula"].ToString();
                        String unidades = datos["Unidades"].ToString();
                        String disponibilidad = datos["Disponibilidad"].ToString();

                        
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
