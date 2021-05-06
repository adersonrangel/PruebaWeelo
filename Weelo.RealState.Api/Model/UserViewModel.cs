using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.RealEstate.Api.Model
{
    /// <summary>
    /// ViewModel para Validacion de token
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Usuario del sistema
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Contraseña de acceso al servicio
        /// </summary>
        public string Token { get; set; }
    }
}
