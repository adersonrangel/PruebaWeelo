using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Dominio
{
    public class PropertyTrace
    {
        [Key()]
        public int IdPropertyTrace { get; set; }
        [Required]
        public DateTime DateSale { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public decimal Tax { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }

    }
}
