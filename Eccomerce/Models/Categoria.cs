﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eccomerce.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}