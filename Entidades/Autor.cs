﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Autor
    {

        private int Id {  get; set; }
        private string Nombre { get; set; }

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
