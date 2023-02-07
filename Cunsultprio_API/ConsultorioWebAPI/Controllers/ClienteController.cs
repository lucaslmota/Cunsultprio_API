using Consultorio.Core.Shared.ModelViews.Cliente;
using ConsultorioCore.Domain;
using ConsultorioManager.InterfacesManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using SerilogTimings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultorioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        private readonly ILogger _logger;
        public ClienteController(IClienteManager clienteManager, ILogger<ClienteController> logger)
        {
            _clienteManager =   clienteManager;
            _logger = logger;
        }
        /// <summary>
        /// Retorna todos os clientes cadastrado na base
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteView), 200)]
        [ProducesResponseType(typeof(ProblemDetails),500)]
        public async Task<IActionResult> Get()
        {
            var cliente = await _clienteManager.GetClientesAsync();

            if(cliente.Any())
            {
                return Ok(cliente);
            }
            return NotFound();
        }

       /// <summary>
       /// Retorna um cliente pelo Id
       /// </summary>
       /// <param name="id" example="123"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteView), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> GetId(int id)
        {
            var cliente = await _clienteManager.GetClienteId(id);
            if(cliente.Id == 0)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        /// <summary>
        /// Insere um novo cliente
        /// </summary>
        /// <param name="novoCliente"></param>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteView), 201)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Post([FromBody] NovoCliente novoCliente)
        {
            //Cliente clienteInserido; registrar os tempos de execução.
            //using(Operation.Time("Foi requisitada a inserção de um novo cliente."))
            //{
            //    _logger.LogInformation("Foi requisitado a inserção de um novo cliente.");
            //     clienteInserido = await _clienteManager.InsertCliente(novoCliente);
            //}
            //return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);

            _logger.LogInformation("Foi requisitado a inserção de um novo cliente.");
            var cadastraCliente = await _clienteManager.InsertCliente(novoCliente);
            return CreatedAtAction(nameof(Get), new {id = cadastraCliente.Id}, cadastraCliente);
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="alterarClientecliente"></param>
        [HttpPut]
        [ProducesResponseType(typeof(ClienteView), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Put([FromBody] AlterarCliente alterarClientecliente)
        {
            var atlaizarCliente = await _clienteManager.UpdateCliente(alterarClientecliente);
            if(atlaizarCliente == null)
            {
                return NotFound();
            }

            return Ok(atlaizarCliente);
        }

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), 204)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCliente = await _clienteManager.DeleteCliente(id);
            return NoContent();
        }
    }
}
