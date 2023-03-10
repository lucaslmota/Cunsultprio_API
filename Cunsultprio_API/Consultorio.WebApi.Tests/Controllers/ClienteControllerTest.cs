using Consultorio.Core.Shared.ModelViews.Cliente;
using Consultorio.FakeData.ClienteData;
using ConsultorioManager.InterfacesManager;
using ConsultorioWebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
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
        private readonly NovoCliente _novoCliente;
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
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(controle);
        }

        [Fact]
        public async Task Get_NotFound()
        {
            _clienteManagerSubstitute.GetClientesAsync().Returns(new List<ClienteView>());

            var resultado = (StatusCodeResult) await _clienteController.Get();

            await _clienteManagerSubstitute.Received().GetClientesAsync();
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task GetById_Ok()
        {
            _clienteManagerSubstitute.GetClienteId(Arg.Any<int>()).Returns(_clienteView.CloneTipado());
            
            var resultado = (ObjectResult)await _clienteController.GetId(_clienteView.Id);

            await _clienteManagerSubstitute.Received().GetClienteId(Arg.Any<int>());
            resultado.Value.Should().BeEquivalentTo(_clienteView);
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetById_NotFound()
        {
            _clienteManagerSubstitute.GetClienteId(Arg.Any<int>()).Returns(new ClienteView());

            var resultado = (StatusCodeResult)await _clienteController.GetId(1);

            await _clienteManagerSubstitute.Received().GetClienteId(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Post_Created()
        {
            _clienteManagerSubstitute.InsertCliente(Arg.Any<NovoCliente>()).Returns(_clienteView.CloneTipado());

            var resultado = (ObjectResult)await _clienteController.Post(_novoCliente);

            await _clienteManagerSubstitute.Received().InsertCliente(Arg.Any<NovoCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status201Created);
            resultado.Value.Should().BeEquivalentTo(_clienteView);
        }

        [Fact]
        public async Task Put_Ok()
        {
            _clienteManagerSubstitute.UpdateCliente(Arg.Any<AlterarCliente>()).Returns(_clienteView.CloneTipado());

            var resultado = (ObjectResult)await _clienteController.Put(new AlterarCliente());

            await _clienteManagerSubstitute.Received().UpdateCliente(Arg.Any<AlterarCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
            resultado.Value.Should().BeEquivalentTo(_clienteView);
        }

        [Fact]
        public async Task Put_NotFound()
        {
            _clienteManagerSubstitute.UpdateCliente(Arg.Any<AlterarCliente>()).ReturnsNull();

            var resultado = (StatusCodeResult)await _clienteController.Put(new AlterarCliente());

            await _clienteManagerSubstitute.Received().UpdateCliente(Arg.Any<AlterarCliente>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Delete_NoContent()
        {
            _clienteManagerSubstitute.DeleteCliente(Arg.Any<int>()).Returns(_clienteView);

            var resultado = (StatusCodeResult)await _clienteController.Delete(1);

            await _clienteManagerSubstitute.Received().DeleteCliente(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task NotFound_NotFound()
        {
            _clienteManagerSubstitute.DeleteCliente(Arg.Any<int>()).ReturnsNull();

            var resultado = (StatusCodeResult)await _clienteController.Delete(1);

            await _clienteManagerSubstitute.Received().DeleteCliente(Arg.Any<int>());
            resultado.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
