using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autor
    {

        public int Id {  get; set; }
        public string Nombre { get; set; }

        public Autor()
        {
        }

        public Autor(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
