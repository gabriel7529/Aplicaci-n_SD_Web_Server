using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicación_SD_Web_Server.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}