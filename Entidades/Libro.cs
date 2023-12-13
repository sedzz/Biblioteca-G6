using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Entidades
{  
    public class Libro : IEquatable<Libro>
    {
        const string cadConexion = "Data Source = localhost; Initial Catalog = BibliotecaG6; Integrated Security = SSPI; MultipleActiveResultSets=true";
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public List<Autor> Autores { get; set; }
        public string Sinopsis { get; set; }
        public string Caratula { get; set; }
        public List<Categoria> Categorias { get; set; }
        public int UnidadesExistentes { get; set; }
        public string Disponibilidad { get; set; }
        public List<Prestamo> Prestamos { get;set; }     


        public Libro()
        {
        }
        public Libro(string isbn)
        {
            Isbn = isbn;
        }

        public Libro(string isbn, string titulo, string editorial, string sinopsis, string caratula, int unidadesExistentes, string disponibilidad)
        {
            Isbn = isbn;
            Titulo = titulo;
            Editorial = editorial;
            Sinopsis = sinopsis;
            Caratula = caratula;
            UnidadesExistentes = unidadesExistentes;
            Disponibilidad = disponibilidad;
        }


        public void ObtenerAutores(out string errores)
        {
            errores = "";

            using(SqlConnection conexion = new SqlConnection(cadConexion))
            {

                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Autor WHERE Autor.ID = (SELECT ID_Autor FROM Escribe WHERE ISBN_Libro = "+this.Isbn+")"; 
                    SqlCommand cmdAutor = new SqlCommand(sql, conexion);
                    SqlDataReader autores = cmdAutor.ExecuteReader();

                    if (!autores.HasRows)
                    {
                        errores = "No hay autores para un libro con este ISBN.";
                    }
                    else
                    {
                        while (autores.Read())
                        {
                            int id = (int)autores["ID"];
                            String nombre = autores["Nombre"].ToString();
                            Autores.Add(new Autor(id, nombre));
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            

        }

        public void ObtenerCategorias(out string errores)
        {
            List<Categoria> categorias = new List<Categoria>();
            errores = "";

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Categorias";
                    SqlCommand cmdCategoria = new SqlCommand(sql, conexion);
                    SqlDataReader drCategorias = cmdCategoria.ExecuteReader();

                    if (!drCategorias.HasRows)
                    {
                        errores = "No hay categorías existentes";
                    }
                    else
                    {
                        while (drCategorias.Read())
                        {
                            int id = (int)drCategorias["ID"];
                            String descripcion = drCategorias["Descripcion"].ToString();
                            Categorias.Add(new Categoria(id, descripcion));
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e; 
                }
            }
        }

        public void ObtenerPrestamos(out string errores)
        {
            List<Prestamo> prestamos = new List<Prestamo>();
            errores = "";

            using (SqlConnection conexion = new SqlConnection(cadConexion))
            {
                try
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Toma_Prestado WHERE ISBN_Libro = @isbn";
                    SqlCommand cmdPrestamo = new SqlCommand(sql, conexion);
                    cmdPrestamo.Parameters.AddWithValue("@isbn", Isbn);
                    SqlDataReader drPrestamo = cmdPrestamo.ExecuteReader();

                    if (!drPrestamo.HasRows)
                    {
                        errores = "No hay categorías existentes";
                    }
                    else
                    {
                        while (drPrestamo.Read())
                        {
                           string numCarnetLector = drPrestamo["NumCarnetLector"].ToString();
                           DateTime fechaPrestamo = (DateTime)drPrestamo["FechaPrestamo"];
                           DateTime fechaDevolucion = (DateTime)drPrestamo["FechaDevolucion"];
                           Prestamos.Add(new Prestamo(numCarnetLector, fechaPrestamo, fechaDevolucion));
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as Libro);
        }

        public bool Equals(Libro other)
        {
            return !(other is null) &&
                   Isbn == other.Isbn;
        }

        public override int GetHashCode()
        {
            return 2140778025 + EqualityComparer<string>.Default.GetHashCode(Isbn);
        }

        public static bool operator ==(Libro left, Libro right)
        {
            return EqualityComparer<Libro>.Default.Equals(left, right);
        }

        public static bool operator !=(Libro left, Libro right)
        {
            return !(left == right);
        }
    }
}
