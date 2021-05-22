using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weelo.Dominio;
using Weelo.LogicaNegocio.Interface;
using Weelo.RealEstate.Api.Model;

namespace Weelo.RealEstate.Api.Controllers
{
    /// <summary>
    /// Controlador de Trace
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTraceController : ControllerBase
    {
        private readonly IPropertyTraceBll propertyTraceBll;

        public PropertyTraceController(ILogger<PropertyTraceController> logger,
                               IPropertyTraceBll propertyTraceBll)
        {
            this.propertyTraceBll = propertyTraceBll;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var propertyTrace = propertyTraceBll.Get(id);
            return Ok(propertyTrace);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var propertyTrace = await propertyTraceBll.GetAll();
            return Ok(propertyTrace);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody]PropertyTraceViewModel propertyTraceViewModel )
        {           

            if (propertyTraceViewModel == null) { return BadRequest(); }

            var propertyTrace = new PropertyTrace()
            {
                DateSale = propertyTraceViewModel.DateSale,
                Name = propertyTraceViewModel.Name,
                PropertyId = propertyTraceViewModel.PropertyId,
                Tax = propertyTraceViewModel.Tax,
                Value = propertyTraceViewModel.Value
            };

            await propertyTraceBll.Add(propertyTrace);
            return Ok(201);
        }
    }
}
