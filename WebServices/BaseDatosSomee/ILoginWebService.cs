using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatosSomee;
using System.Data.Entity;

namespace BaseDatosSomee
{
    public interface ILoginWebService : IDisposable
    {
        DbSet<ServiceUsuario> Usuarios { get; set; }
        DbSet<ServiceToken> ServiceTokens { get; set; }

    }
}
