using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Entidades
{
    public class Prestamo 
    {
        public string NumCarnetLector { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }

        public Prestamo() { }
        public Prestamo(string NumCarnetLector, DateTime FechaPrestamo, DateTime FechaDevolucion)
        {

            this.NumCarnetLector = NumCarnetLector;
            this.FechaPrestamo = FechaPrestamo;
            this.FechaDevolucion = FechaDevolucion;

        }
    }
}
