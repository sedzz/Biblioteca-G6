using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lector
    {
        public string NumCarnet {  get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public string Gmail {  get; set; }

        public Lector()
        {
        }
        public Lector(string numCarnet)
        {
            NumCarnet = numCarnet;
        }
            public Lector(string numCarnet, string nombre, string contraseña, string telefono, string gmail)
        {
            NumCarnet = numCarnet;
            Nombre = nombre;
            Contraseña = contraseña;
            Telefono = telefono;
            Gmail = gmail;
        }
    }
}
