using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weelo.RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        public OwnerController(ILogger<OwnerController> logger)
        {

        }
        [HttpGet]
        public ActionResult Get(int id) {
            return Ok();
        }
    }
}
