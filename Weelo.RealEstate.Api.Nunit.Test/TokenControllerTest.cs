using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weelo.Dominio;
using Weelo.LogicaNegocio.Interface;
using Weelo.RealEstate.Api.Controllers;
using Weelo.RealEstate.Api.Model;

namespace Weelo.RealEstate.Api.Nunit.Test
{
    [TestFixture]
    public class TokenControllerTest
    {
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public async Task Test1()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<TokenController>>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockRepo = new Mock<ISeguridadBll>();
            mockRepo.Setup(repo => repo.ValidarUsuario("Cliente","passwordSeguro1234567")).ReturnsAsync(GetTestCliente());
            var controller = new TokenController(mockLogger.Object,mockConfiguration.Object, mockRepo.Object);

            TokenViewModel tokenViewModel = new TokenViewModel() {
                User = "Cliente",
                Password = "passwordSeguro1234567"
            };

            // Act
            var result = await controller.Post(tokenViewModel);

            // Assert
            Assert.IsInstanceOf<TokenViewModel>(result);
            //var model = Assert.IsAssignableFrom<ResponseViewModel>
            //    viewResult.ViewData.Model);

            //Assert.Equal(2, model.Count());


        }


        private Cliente GetTestCliente()
        {
            Cliente cliente = new()
            {
                Ciudad = "68001",
                Clave = "1234567",
                Estado = 1,
                Usuario = "Cliente"
            };

            return cliente;
        }
    }
}