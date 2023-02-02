using AutoMapper;
using Consultorio.Core.Shared.ModelViews.Cliente;
using ConsultorioCore.Domain;
using ConsultorioManager.Interfaces;
using ConsultorioManager.InterfacesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.Implementations
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteManager(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteId(int id)
        {
            return await _clienteRepository.GetClienteId(id);
        }

        public async Task<Cliente> InsertCliente(NovoCliente novoCliente)
        {
            var cliente = _mapper.Map<Cliente>(novoCliente);
            return await _clienteRepository.InsertCliente(cliente);
        }

        public async Task<Cliente> UpdateCliente(AlterarCliente alterarClientecliente)
        {
            var cliente = _mapper.Map<Cliente>(alterarClientecliente);
            return await _clienteRepository.UpdateCliente(cliente);
        }

        public async Task<Cliente> DeleteCliente(int id)
        {
           return await _clienteRepository.DeleteCliente(id);
        }
    }
}
