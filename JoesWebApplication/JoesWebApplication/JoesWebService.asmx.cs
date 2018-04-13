using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace JoesWebApplication
{
    /// <summary>
    /// Descripción breve de JoesWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class JoesWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string HelloWorldByUser(string usr, string pwd)
        { 
            if (usr.ToLower().Trim() == "jhon" && pwd.ToLower().Trim() == "puin")
            {
                return "Hello AUTHENTICATED USER";
            }
            else
            {
                return "DENIED - AUTHENTICATED USER";
            }
            //return "Hola a todos " + System.Reflection.MethodBase.GetCurrentMethod().Name;
        }

        [WebMethod]
        public string HelloWorldByToken(string authToken)
        {
            return "Hola a todos " + System.Reflection.MethodBase.GetCurrentMethod().Name;
        }
    }
}
