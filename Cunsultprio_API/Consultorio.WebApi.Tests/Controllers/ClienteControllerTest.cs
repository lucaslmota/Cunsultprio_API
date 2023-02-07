using Consultorio.Core.Shared.ModelViews.Cliente;
using Consultorio.FakeData.ClienteData;
using ConsultorioManager.InterfacesManager;
using ConsultorioWebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Consultorio.WebApi.Tests.Controllers
{
    public class ClienteControllerTest
    {
        private readonly IClienteManager _clienteManagerSubstitute;
        private readonly ILogger<ClienteController> _loggerSubstitute;
        private readonly ClienteController _clienteController;

        private readonly ClienteView _clienteView;
        private readonly List<ClienteView> _clienteViewsList;
        public ClienteControllerTest()
        {
            _clienteManagerSubstitute = Substitute.For<IClienteManager>();
            _loggerSubstitute = Substitute.For<ILogger<ClienteController>>();
            _clienteController = new ClienteController(_clienteManagerSubstitute, _loggerSubstitute);

            _clienteView = new ClienteViewFake().Generate();
            _clienteViewsList = new ClienteViewFake().Generate(10);
        }

        [Fact]
        public async Task Get_OK()
        {
            var controle = new List<ClienteView>();
            _clienteViewsList.ForEach(x => controle.Add(x.CloneTipado()));

            _clienteManagerSubstitute.GetClientesAsync().Returns(_clienteViewsList);
            var resultado = (ObjectResult) await _clienteController.Get();
            resultado.StatusCode.Should().Be(200);
            resultado.Value.Should().BeEquivalentTo(controle);
        }
    }
}
