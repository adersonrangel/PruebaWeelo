using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.RealEstate.Api.Model
{
    public class PropertyTraceViewModel
    {
       
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
       
    }
}
