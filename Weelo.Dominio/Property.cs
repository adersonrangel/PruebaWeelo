using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.Dominio
{
    public class Property
    {
        [Key]
        public int IdProperty { get; set; }

        [MaxLength(350)]
        public string  Name { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

       
        public decimal Price { get; set; }

        [MaxLength(5)]
        public string CodeInternal { get; set; }

        [MaxLength(4)]
        public string Year { get; set; }

       
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }


    }
}
