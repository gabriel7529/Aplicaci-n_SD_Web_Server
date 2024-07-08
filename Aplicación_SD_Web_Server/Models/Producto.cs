using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicación_SD_Web_Server.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioOferta { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}