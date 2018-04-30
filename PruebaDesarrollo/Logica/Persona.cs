using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Datos;
using Entities.DTO;


namespace Logica
{
    public class Persona
    {
        public static List<PersonaDTO> ObtenerPersonas()
        {
            DataTable personasDatatable = new DataTable();
            using (Soporte_SISEEntities db = new Soporte_SISEEntities())
            {
                var personas = db.Personas.Join(db.TipoIdentificacions,
                p => p.TipoIdentificacionId,
                t => t.Id,
                (p, t) => new PersonaDTO
                {
                    Id = p.Id,
                    TipoIdentificacion = t.Tipo,
                    Estado = p.Estado,
                    Nombre = p.Nombre,
                    NumeroIdentificacion = p.NumeroIdentificacion
                }).ToList();

                return personas;
            }

        }

        public static PersonaDTO ObtenerPersonaPorId(int? id)
        {
            DataTable personasDatatable = new DataTable();
            using (Soporte_SISEEntities db = new Soporte_SISEEntities())
            {
                var persona = db.Personas.Where(p => p.Id == id).Select(p => new PersonaDTO
                {
                    Id = p.Id,
                    Estado = p.Estado,
                    Nombre = p.Nombre,
                    NumeroIdentificacion = p.NumeroIdentificacion,
                    TipoIdentificacionId = p.TipoIdentificacionId
                }).FirstOrDefault();

                return persona;
            }

        }

        public static string ModificarPersona(PersonaDTO personaDTO)
        {

            if (personaDTO.Nombre.Length <= 30)
            {
                if (!nombreCorrecto(personaDTO.Nombre))
                {
                    return "En nombre solo debe tener caractere alfabeticos con espacios.";
                }
            }
            else
            {
                return "El nombre debe tener maximo 30 caracteres.";
            }

            if (personaDTO.NumeroIdentificacion.Trim().Length < 20)
            {
                if (personaDTO.TipoIdentificacionId != 3)
                {
                    if (!numeroCorrecto(personaDTO.NumeroIdentificacion))
                    {
                        return "Solo se permiten números para este tipo de identificación";
                    }
                }
                else
                {
                    if (!nitCorrecto(personaDTO.NumeroIdentificacion))
                    {
                        return "Solo se permiten caracteres alfanumericos para este tipo de identificación";
                    }
                }
            }
            else
            {
                return "La longitud de los caracteres debe ser menor o igual a 20";
            }



            using (Soporte_SISEEntities db = new Soporte_SISEEntities())
            {
                var persona = db.Personas.FirstOrDefault(p => p.Id == personaDTO.Id);
                persona.TipoIdentificacionId = personaDTO.TipoIdentificacionId;
                persona.Estado = personaDTO.Estado;
                persona.Nombre = personaDTO.Nombre;
                persona.NumeroIdentificacion = personaDTO.NumeroIdentificacion;
                db.SaveChanges();
                return "ok";
            }
        }

        //public static string ModificarPersona (int id, string tipoIdentificacionId, string numeroIdentificacion, string nombre, bool estado)
        //{
        //    if (ModelStateDictionary.IsValid)
        //    {

        //    }
        //    var _tipoIdentificacionId = Int32.Parse(tipoIdentificacionId);

        //    if (nombre.Length <= 30)
        //    {
        //        if (!nombreCorrecto(nombre))
        //        {
        //            return "En nombre solo debe tener caractere alfabeticos con espacios.";
        //        }
        //    }
        //    else
        //    {
        //        return "El nombre debe tener maximo 30 caracteres.";
        //    }

        //    if (numeroIdentificacion.Trim().Length < 20)
        //    {
        //        if (_tipoIdentificacionId != 3)
        //        {
        //            if (!numeroCorrecto(numeroIdentificacion))
        //            {
        //                return "Solo se permiten números para este tipo de identificación";
        //            }
        //        }
        //        else
        //        {
        //            if (!nitCorrecto(numeroIdentificacion))
        //            {
        //                return "Solo se permiten caracteres alfanumericos para este tipo de identificación";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return "La longitud de los caracteres debe ser menor o igual a 20";
        //    }



        //    using (Soporte_SISEEntities db = new Soporte_SISEEntities())
        //    {
        //        var persona = db.Personas.FirstOrDefault(p => p.Id == id);
        //        persona.TipoIdentificacionId = _tipoIdentificacionId;
        //        persona.Estado = estado;
        //        persona.Nombre = nombre;
        //        persona.NumeroIdentificacion = numeroIdentificacion;
        //        db.SaveChanges();
        //        return "ok";
        //    }
        //}

        public static string CrearPersona(string tipoIdentificacionId, string numeroIdentificacion, string nombre, bool estado)
        {

            var _tipoIdentificacionId = Int32.Parse(tipoIdentificacionId);

            if (nombre.Length <= 30)
            {
                if (!nombreCorrecto(nombre))
                {
                    return "En nombre solo debe tener caractere alfabeticos con espacios.";
                }
            }
            else
            {
                return "El nombre debe tener maximo 30 caracteres.";
            }
            if (numeroIdentificacion.Trim().Length < 20)
            {
                if (_tipoIdentificacionId != 3)
                {
                    if (!numeroCorrecto(numeroIdentificacion))
                    {
                        return "Solo se permiten números para este tipo de identificación";
                    }
                }
                else
                {
                    if (!nitCorrecto(numeroIdentificacion))
                    {
                        return "Solo se permiten caracteres alfanumericos para este tipo de identificación";
                    }
                }
            }
            else
            {
                return "La longitud de los caracteres debe ser menor o igual a 20";
            }

            var personaDTO = new PersonaDTO()
            {
                TipoIdentificacionId = _tipoIdentificacionId,
                Estado = estado,
                Nombre = nombre,
                NumeroIdentificacion = numeroIdentificacion
            };

            


            using (Soporte_SISEEntities db = new Soporte_SISEEntities())
            {
                var persona = new Datos.Persona()
                {
                    TipoIdentificacionId = personaDTO.TipoIdentificacionId,
                    Estado = personaDTO.Estado,
                    Nombre = personaDTO.Nombre,
                    NumeroIdentificacion = personaDTO.NumeroIdentificacion
                };

                db.Personas.Add(persona);
                db.SaveChanges();
                return "ok";
            }
            //return string.Format("Persona: {0}, almacenada correctamete", nombre);

        }


        public static Boolean numeroCorrecto(String nombre)
        {
            String expresion;
            expresion = "[0-9]";
            nombre = nombre.Replace(" ", "");
            if (Regex.IsMatch(nombre, expresion))
            {
                if (Regex.Replace(nombre, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Boolean nitCorrecto(String nombre)
        {
            String expresion;
            expresion = "[0-9a-zA-ZñÑ]";
            nombre = nombre.Replace(" ", "");
            if (Regex.IsMatch(nombre, expresion))
            {
                if (Regex.Replace(nombre, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Boolean nombreCorrecto(String nombre)
        {
            String expresion;
            expresion = "[a-zA-ZñÑ]";
            nombre = nombre.Replace(" ", "");
            if (Regex.IsMatch(nombre, expresion))
            {
                if (Regex.Replace(nombre, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
