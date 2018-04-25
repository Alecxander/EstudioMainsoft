using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class ProductoDetalleDTO
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public decimal Precio { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime FechaCreacion { get; set; }
    }
}