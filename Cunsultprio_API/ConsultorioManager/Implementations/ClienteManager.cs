using AutoMapper;
using Consultorio.Core.Shared.ModelViews.Cliente;
using ConsultorioCore.Domain;
using ConsultorioManager.Interfaces;
using ConsultorioManager.InterfacesManager;
using Microsoft.Extensions.Logging;
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

        public async Task<IEnumerable<ClienteView>> GetClientesAsync()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteView>>(clientes);
        }

        public async Task<ClienteView> GetClienteId(int id)
        {
            var cliente = await _clienteRepository.GetClienteId(id);
            return _mapper.Map<ClienteView>(cliente);
        }

        public async Task<ClienteView> InsertCliente(NovoCliente novoCliente)
        {
            var cliente = _mapper.Map<Cliente>(novoCliente);
            cliente = await _clienteRepository.InsertCliente(cliente);
            return _mapper.Map<ClienteView>(cliente);
        }

        public async Task<ClienteView> UpdateCliente(AlterarCliente alterarClientecliente)
        {
            var cliente = _mapper.Map<Cliente>(alterarClientecliente);
            cliente = await _clienteRepository.UpdateCliente(cliente);
            return _mapper.Map<ClienteView>(cliente);
        }

        public async Task<ClienteView> DeleteCliente(int id)
        {
            var cliente = await _clienteRepository.DeleteCliente(id);
            return _mapper.Map<ClienteView>(cliente);
        }
    }
}
