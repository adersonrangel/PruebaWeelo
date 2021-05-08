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
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyBll propertyBll;

        public PropertyController(ILogger<PropertyController> logger,
                               IPropertyBll propertyBll)
        {
            this.propertyBll = propertyBll;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var property = propertyBll.Get(id);
            return Ok(property);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var property = await propertyBll.GetAll();
            return Ok(property);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PropertyViewModel propertyViewModel)
        {

            if (propertyViewModel == null) { return BadRequest(); }

            var property = new Property()
            {
                Address = propertyViewModel.Address,
                Name = propertyViewModel.Name,
                CodeInternal = propertyViewModel.CodeInternal,
                Price = propertyViewModel.Price,
                Year = propertyViewModel.Year,
                OwnerId = propertyViewModel.OwnerId
            };

            await propertyBll.Add(property);
            return Ok(201);
        }
    }
}
