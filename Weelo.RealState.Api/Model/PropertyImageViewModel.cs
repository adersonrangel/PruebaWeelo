using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.RealEstate.Api.Model
{
    /// <summary>
    /// PropertyImage ViewModel
    /// </summary>
    public class PropertyImageViewModel
    {
        
        public int IdPropertyImage { get; set; }

        public Byte[] File { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public int PropertyId { get; set; }

        public PropertyViewModel Property { get; set; }

    }
}
