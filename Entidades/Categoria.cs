using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria : IEquatable<Categoria>
    {
        public int Id {  get; set; }
        public string Descripcion { get; set; }

        public Categoria()
        {
        }

        public Categoria(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Categoria);
        }

        public bool Equals(Categoria other)
        {
            return !(other is null) &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }

}
