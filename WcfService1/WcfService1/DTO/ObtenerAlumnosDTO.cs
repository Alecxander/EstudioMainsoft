using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1.DTO
{
    [DataContract]
    public class ObtenerAlumnosDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Materia { get; set; }
        [DataMember]
        public string Profesor { get; set; }
    }

    [DataContract]
    public class ObtenerAlumnosDTOLista
    {
        [DataMember]
        public List<ObtenerAlumnosDTO> obtenerAlumnosDTOs { get; set; }
    }
}