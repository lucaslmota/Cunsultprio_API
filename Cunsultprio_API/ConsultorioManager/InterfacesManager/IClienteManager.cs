using Consultorio.Core.Shared.ModelViews;
using ConsultorioCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.InterfacesManager
{
    public interface IClienteManager
    {
        Task<Cliente> GetClienteId(int id);
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> InsertCliente(NovoCliente cliente);
        Task<Cliente> UpdateCliente(AlterarCliente cliente);
        Task<Cliente> DeleteCliente(int id);
    }
}
