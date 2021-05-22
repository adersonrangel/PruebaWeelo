using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.RealEstate.Api.Model
{
    /// <summary>
    /// ViewModel para Token de VAlidacion
    /// </summary>
    public class TokenViewModel
    {
        /// <summary>
        /// Usuario del sistema
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Contraseña de acceso al servicio
        /// </summary>
        public string Password { get; set; }
    }
}
