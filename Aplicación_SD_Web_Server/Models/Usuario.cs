using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplicación_SD_Web_Server.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}