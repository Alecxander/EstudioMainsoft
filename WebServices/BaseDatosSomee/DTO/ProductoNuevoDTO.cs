using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatosSomee.DTO
{
    public class ProductoNuevoDTO
    {
        public int ProductoCategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public decimal Precio { get; set; }
    }
}
