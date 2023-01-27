using ConsultorioCore.Domain;
using ConsultorioData.Context;
using ConsultorioManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioData.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ConsultorioContext _consultorioContext;

        public ClienteRepository(ConsultorioContext consultorioContext)
        {
            _consultorioContext = consultorioContext;
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _consultorioContext.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefone)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente> GetClienteId(int id)
        {
            return await _consultorioContext.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefone)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> InsertCliente(Cliente cliente)
        {
            await _consultorioContext.Clientes.AddAsync(cliente);
            await _consultorioContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            var getCliente = await GetClienteId(cliente.Id);
            if(cliente == null)
            {
                return null;
            }

            _consultorioContext.Entry(getCliente).CurrentValues.SetValues(cliente);
            await _consultorioContext.SaveChangesAsync();
            return getCliente;
        }

        public async Task<Cliente> DeleteCliente(int id)
        {
            var getCliente = await GetClienteId(id);
            _consultorioContext.Remove(getCliente);
            return getCliente;
        }
    }
}
