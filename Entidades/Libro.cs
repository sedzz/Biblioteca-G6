using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Entidades
{
    public class Libro : IEquatable<Libro>
    {
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

        public Libro(string isbn, string titulo, string editorial, List<Autor> autores, string sinopsis, string caratula, List<Categoria> categorias, int unidadesExistentes, string disponibilidad, List<Prestamo> prestamos)
        {
            Isbn = isbn;
            Titulo = titulo;
            Editorial = editorial;
            Autores = autores;
            Sinopsis = sinopsis;
            Caratula = caratula;
            Categorias = categorias;
            UnidadesExistentes = unidadesExistentes;
            Disponibilidad = disponibilidad;
            Prestamos = prestamos;
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
