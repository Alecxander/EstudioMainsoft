using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTO
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string TipoIdentificacion { get; set; }
        public Nullable<int> TipoIdentificacionId { get; set; }
        public string NumeroIdentificacion { get; set; }
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Debe ser mayor a 5 y menor a 10 caracteres.")]
        public string Nombre { get; set; }
        public Nullable<bool> Estado { get; set; }
        
    }
}
