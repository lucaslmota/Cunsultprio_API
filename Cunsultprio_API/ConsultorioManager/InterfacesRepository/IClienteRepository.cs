using ConsultorioCore.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultorioManager.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteId(int id);
        Task<Cliente> InsertCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task<Cliente> DeleteCliente(int id);
    }
}
