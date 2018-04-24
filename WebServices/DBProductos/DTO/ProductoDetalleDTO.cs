using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProductos.DTO
{
    public class ProductoDetalleDTO
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public decimal Precio { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    }
}
