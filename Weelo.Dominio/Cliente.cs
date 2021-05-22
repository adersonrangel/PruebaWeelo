using System;
using System.ComponentModel.DataAnnotations;

namespace Weelo.Dominio
{
    /// <summary>
    /// Cliente se seguridad del sistema
    /// </summary>
    public class Cliente
    {
        public string Ciudad { get; set; }

        [MaxLength(10)]
        public string Usuario { get; set; }

        [MaxLength(8)]
        public string Clave { get; set; }

        public SByte Estado { get; set; }
    }
}
