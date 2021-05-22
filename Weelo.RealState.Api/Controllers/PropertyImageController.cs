using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Weelo.Dominio;
using Weelo.LogicaNegocio.Interface;
using Weelo.RealEstate.Api.Model;

namespace Weelo.RealEstate.Api.Controllers
{
    /// <summary>
    /// Controlador de PropertyImage
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageBll propertyImageBll;

        public PropertyImageController(ILogger<PropertyImageController> logger,
                               IPropertyImageBll propertyImageBll)
        {
            this.propertyImageBll = propertyImageBll;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var propertyImage = propertyImageBll.Get(id);
            return Ok(propertyImage);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var propertyImage = await propertyImageBll.GetAll();
            return Ok(propertyImage);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] IFormCollection propertyImageViewModel)
        {
            if (propertyImageViewModel == null) { return BadRequest(); }           
            if (propertyImageViewModel.Files.Count == 0) { return BadRequest(); }

            PropertyImage propertyImage = new()
            {
                Enabled = bool.Parse(propertyImageViewModel["Enabled"]),
                PropertyId = int.Parse(propertyImageViewModel["PropertyId"]),            
            };

            using (MemoryStream ms = new MemoryStream())
            {
                propertyImageViewModel.Files[0].CopyTo(ms);
                byte[] array = ms.GetBuffer();
                propertyImage.File = array;
            }

            await propertyImageBll.Add(propertyImage);
            return Ok(201);
        }
    }
}
