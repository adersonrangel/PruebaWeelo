using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Weelo.LogicaNegocio.Interface;
using Weelo.RealEstate.Api.Model;
using Weelo.Transversal.Message.Service;

namespace Weelo.RealEstate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ISeguridadBll seguridadBll;

        public TokenController(ILogger<TokenController> logger ,
                                IConfiguration configuration,
                                ISeguridadBll seguridadBll)
        {
            this.configuration = configuration;
            this.seguridadBll = seguridadBll;
        }

        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TokenViewModel tokenViewModel)
        {
            ResponseViewModel<UserViewModel> response = new ResponseViewModel<UserViewModel>();
            UserViewModel userViewModel = new UserViewModel();
            string token = string.Empty;
            sbyte userActivo = 0;

            if (await EsUsuarioValido(tokenViewModel.User, tokenViewModel.Password))
            {
                var result = await GenerarToken(tokenViewModel.User, tokenViewModel.Password);
                userActivo = result.UserActivo;
                token = result.Access_Token;
            }

            if (!String.IsNullOrEmpty(token))
            {
                if (userActivo == 1)
                {
                    response.Data = new UserViewModel() { Token = token, User = tokenViewModel.User };
                    response.MessageOk = new MessageOk() { Code = "1001", Description = "Usuario encontrado." };
                }
                else
                {
                    response.MessageError = new MessageError() { Code = "1003", Description = "Usuario Inactivo." };
                }
            }
            else
            {
                response.MessageError = new MessageError() { Code = "1002", Description = "Usuario no encontrado." };
            }

            return Ok(response);
            
        }


        /// <summary>
        /// Valida si un usuario se encuentra permitido en el sistema.
        /// </summary>
        /// <param name="usuario">Nombre del usuario de consulta asignado</param>
        /// <param name="password">Contraseña asignada dentro del sistema</param>
        /// <returns>Verdadero o Falso dependiendo del resultado</returns>
        private async Task<bool> EsUsuarioValido(string usuario, string password)
        {
            var user = await seguridadBll.ValidarUsuario(usuario, password);

            if (user != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Genera el Token en formato JWT
        /// </summary>
        /// <param name="usuario">Nombre de usuario a consultar</param>
        /// <param name="clave">Clave de usaurio asignada</param>
        /// <returns>Objeto dinamico con la asignación del token. Variables  Access_Token y UserName </returns>
        private async Task<dynamic> GenerarToken(string usuario, string clave)
        {
            var key = Encoding.UTF8.GetBytes(configuration["Identity:Key"]);
            var user = await seguridadBll.ValidarUsuario(usuario, clave);


            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, usuario));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Ciudad));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()));
            claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()));


            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "Usuario"));


            var tokenHandler = new JwtSecurityTokenHandler();


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(30),
                Audience = "Weelo.Api",
                Issuer = "api",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenRespuesta = tokenHandler.CreateToken(tokenDescriptor);

            var output = new
            {
                Access_Token = tokenHandler.WriteToken(tokenRespuesta),
                UserName = user.Usuario,
                UserActivo = user.Estado
            };

            return output;
        }
    }
}
