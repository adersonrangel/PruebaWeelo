using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.Dominio;

namespace Weelo.LogicaNegocio.Interface
{
    public interface ISeguridadBll
    {
        Task<Cliente> ValidarUsuario(string usuario, string clave);
    }
}
