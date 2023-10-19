using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : IEquatable<Libro>
    {
        private string Isbn { get; set; }
        private string Titulo { get; set; }
        private string Editorial {  get; set; }
        private string Autor {  get; set; }
        private string Sinopsis {  get; set; }
        private string Caratula {  get; set; }
        private string Categoria {get; set;}
        private int UnidadesExistentes {  get; set; }
        private Boolean Disponibilidad {  get; set; }










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
