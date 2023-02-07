using Consultorio.Core.Shared.ModelViews.Cliente;
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
        Task<ClienteView> GetClienteId(int id);
        Task<IEnumerable<ClienteView>> GetClientesAsync();
        Task<ClienteView> InsertCliente(NovoCliente cliente);
        Task<ClienteView> UpdateCliente(AlterarCliente cliente);
        Task<ClienteView> DeleteCliente(int id);
    }
}
