using ConsultorioCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.InterfacesRepository
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetMedicosAsync();

        Task<Medico> GetMedicoAsync(int id);

        Task<Medico> InsertMedicoAsync(Medico medico);

        Task<Medico> UpdateMedicoAsync(Medico medico);

        Task DeleteMedicoAsync(int id);
    }
}
