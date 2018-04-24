using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DB;
using WcfService1.DTO;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        List<ObtenerAlumnosDTO> obtener = new List<ObtenerAlumnosDTO>();

        //IEnumerable<ObtenerAlumnosDTO> IService1.GetAlumnosDTOs()
        //{
        //    LoginServiceEntities db = new LoginServiceEntities();
        //    var alumnos = db.ObtenerAlumnos().Select(p => new ObtenerAlumnosDTO {
        //        Profesor = p.Profesor,
        //        Nombre = p.Nombre,
        //        Materia = p.Materia,
        //        Id = p.Id,
        //        Correo = p.Correo
        //    });           

        //    return alumnos;
        //}

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<ObtenerAlumnosDTO> ObtenerAlumnos()
        {
            LoginServiceEntities db = new LoginServiceEntities();
            var alumnos = db.ObtenerAlumnos().Select(p => new ObtenerAlumnosDTO
            {
                Profesor = p.Profesor,
                Nombre = p.Nombre,
                Materia = p.Materia,
                Id = p.Id,
                Correo = p.Correo
            }).ToList();

            return alumnos;
        }

        public string Saludar(string saludo)
        {
            return saludo + " Jhon Alexander";
        }

        ObtenerAlumnosDTO IService1.GetAlumno(int idAlumno)
        {
            LoginServiceEntities loginServiceEntities = new LoginServiceEntities();
            var alumno = loginServiceEntities.ObtenerUsuariosPorIDSP(idAlumno).Select(p => new ObtenerAlumnosDTO {
                Id = p.Id,
                Correo = p.Correo,
                Materia = p.Materia,
                Nombre = p.Nombre,
                Profesor = p.Profesor
            }).FirstOrDefault(); 
            return alumno;
        }

    }
}
