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
    public class TokenController : ControllerBase
    {

        public TokenController(ILogger<TokenController> logger)
        {

        }

        
        [HttpPost]
        public ActionResult Post()
        {
            return Ok();
        }
    }
}
