using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TemperatureWebService
{
    /// <summary>
    /// Descripción breve de TemperatureService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TemperatureService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public double FahrenheitToCelsius(double Fahrenheit)
        {
            return ((Fahrenheit - 32) * 5) / 9;
        }

        [WebMethod]
        public double CelsiusToFahrenheit(double Celsius)
        {
            return ((Celsius * 9) / 5 + 32);
        }
    }
}
