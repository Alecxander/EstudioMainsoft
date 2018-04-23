using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
//using BaseDatosSomee;
//using BaseDatos;
using BaseDatosSomee.DTO;
using DBLogin;
using DBProductos;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de Login
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Login : System.Web.Services.WebService
    {

        [WebMethod (CacheDuration = 0, Description = "Metodo que crea token si el usuario y contraseña son correctos", MessageName = "Metodo_login")]
        public string LoginByUserAndPassword(string usuario, string password)
        {
            using (LoginWebServiceLoginEntities db = new LoginWebServiceLoginEntities())
            {
                var usuarioDB = db.ServiceUsuarios.FirstOrDefault(u => u.Usuario.Trim() == usuario.Trim() && u.Password.Trim() == password.Trim());

                if (usuarioDB != null)
                {
                    var newToken = Guid.NewGuid();
                    ServiceToken newServiceToken = new ServiceToken();
                    newServiceToken.Token = newToken;
                    newServiceToken.Fecha_creacion = DateTime.Now;
                    db.ServiceTokens.Add(newServiceToken);
                    db.SaveChanges();
                    return newToken.ToString();
                }
                return "";
            }
        }

        [WebMethod (Description = "Valida que si el token todavia esta activo y se puede utilizar.")]
        public bool validarToken(string token)
        {
            bool tokenValido = false;
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return tokenValido;
                }
                else
                {
                    Guid userToken;
                    //Guid userToken = new Guid(token);
                    if (Guid.TryParse(token, out userToken))
                    {
                        using (LoginWebServiceLoginEntities db = new LoginWebServiceLoginEntities())
                        {
                            var tresHorasAntes = DateTime.Now.AddMinutes(-10); //DateTime.Now.AddHours(-3);
                            var dbToken = db.ServiceTokens.FirstOrDefault(t => t.Token == userToken);
                            if (dbToken != null && dbToken.Fecha_creacion > tresHorasAntes)
                            {
                                tokenValido = true;
                            }
                            else
                            {
                                db.ServiceTokens.Remove(dbToken);
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return tokenValido;
        }

        [WebMethod (Description = "Elimina un Token activo, para cuando el usuario cierre sesión")]
        public bool eliminarToken(string token)
        {
            bool tokenEliminado = false;
            try
            {
                Guid userToken = new Guid(token);
                if (userToken != null)
                {
                    using (LoginWebServiceLoginEntities db = new LoginWebServiceLoginEntities())
                    {
                        var myToken = db.ServiceTokens.FirstOrDefault(t => t.Token == userToken);
                        if (myToken != null)
                        {
                            db.ServiceTokens.Remove(myToken);
                            db.SaveChanges();
                            tokenEliminado = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tokenEliminado;
        }

        
    }
}
