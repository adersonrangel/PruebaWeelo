using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.RealEstate.Api.Model
{
    public class OwnerViewModel
    {
      
        public int IdOwner { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }


        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
    }
}
