using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Biblioteca
    {
        private String Nombre {  get; set; }
        private String Lugar { get; set; }

        private String Logo { get; set; }

        public Biblioteca()
        {
        }

        public Biblioteca(string nombre, string lugar, string logo)
        {
            Nombre = nombre;
            Lugar = lugar;
            Logo = logo;
        }


    }
}
