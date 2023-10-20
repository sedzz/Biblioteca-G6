using System;

namespace Entidades
{
    internal class LibroPrestado : Libro
    {
        private DateTime FechaPrestamo { get; set; }
        private DateTime FechaDevolucion { get; set; }

        public LibroPrestado(string isbn, string titulo, string editorial, string autor, string sinopsis, string caratula, string categoria, int unidadesExistentes, string disponibilidad, DateTime fechaPrestamo, DateTime fechaDevolucion)
            : base(isbn, titulo, editorial, autor, sinopsis, caratula, categoria, unidadesExistentes, disponibilidad)
        {
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
        }
    }
}
