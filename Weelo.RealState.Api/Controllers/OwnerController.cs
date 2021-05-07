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
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerBll ownerBll;

        public OwnerController(ILogger<OwnerController> logger,
                               IOwnerBll ownerBll)
        {
            this.ownerBll = ownerBll;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id) {

            var owner = ownerBll.Get(id);
            return Ok(owner);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {

            var owners = await ownerBll.GetAll();
            return Ok(owners);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody]OwnerViewModel ownerViewModel)
        {        

            if (ownerViewModel == null) { return BadRequest();}
            if (ownerViewModel.Photo == null) { return BadRequest(); }

            Owner owner = new()
            {
                Name = ownerViewModel.Name,
                Address = ownerViewModel.Address,
                Birthday = ownerViewModel.Birthday
            };

            using (MemoryStream ms = new MemoryStream()){
                    ownerViewModel.Photo.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                owner.Photo= array;
            }        
  
            await ownerBll.Add(owner);
            return Ok(201);
        }
    }
}
