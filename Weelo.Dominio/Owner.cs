using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Dominio
{
    public class Owner
    {
        [Key]
        public int IdOwner { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

       
        public Byte[] Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

    }
}
