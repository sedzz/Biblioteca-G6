using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Usuario
    {
        private string NumCarnet {  get; set; }
        private string Nombre { get; set; }
        private string Contraseña { get; set; }
        private string Telefono { get; set; }
        private string Gmail {  get; set; }

        public Usuario()
        {
        }

        public Usuario(string numCarnet, string nombre, string contraseña, string telefono, string gmail)
        {
            NumCarnet = numCarnet;
            Nombre = nombre;
            Contraseña = contraseña;
            Telefono = telefono;
            Gmail = gmail;
        }
    }
}
