using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Dominio
{
    public class PropertyImage
    {
        [Key]
        public int IdPropertyImage { get; set; }
        
        
        public Byte[] File { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
