using Consultorio.Core.Shared.ModelViews;
using ConsultorioCore.Domain;
using ConsultorioManager.InterfacesManager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultorioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        public ClienteController(IClienteManager clienteManager)
        {
            _clienteManager =   clienteManager;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _clienteManager.GetClientesAsync());
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            return Ok( await _clienteManager.GetClienteId(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NovoCliente novoCliente)
        {
            var cadastraCliente = await _clienteManager.InsertCliente(novoCliente);
            return CreatedAtAction(nameof(Get), new {id = cadastraCliente.Id}, cadastraCliente);
        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AlterarCliente alterarClientecliente)
        {
            var atlaizarCliente = await _clienteManager.UpdateCliente(alterarClientecliente);
            if(atlaizarCliente == null)
            {
                return NotFound();
            }

            return Ok(atlaizarCliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCliente = await _clienteManager.DeleteCliente(id);
            return NoContent();
        }
    }
}
