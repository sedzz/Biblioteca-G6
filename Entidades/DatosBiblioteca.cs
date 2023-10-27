using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DatosBiblioteca
    {
        public String Nombre {  get; set; }
        public String Lugar { get; set; }

        public String Logo { get; set; }


        public DatosBiblioteca()
        {
        }

        public DatosBiblioteca(string nombre, string lugar, string logo)
        {
            Nombre = nombre;
            Lugar = lugar;
            Logo = logo;
        }


    }
}
