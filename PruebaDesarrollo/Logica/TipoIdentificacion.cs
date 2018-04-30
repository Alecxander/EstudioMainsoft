using Datos;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class TipoIdentificacion
    {
        public static List<TipoIdentificacionDTO> ObtenerTipoIdentificacion()
        {
            using (Soporte_SISEEntities db = new Soporte_SISEEntities())
            {
                var identificaciones = db.TipoIdentificacions.Select(t => new TipoIdentificacionDTO
                {
                    Id = t.Id,
                    Tipo = t.Tipo
                }).ToList();

                return identificaciones;
            }
        }
    }
}
