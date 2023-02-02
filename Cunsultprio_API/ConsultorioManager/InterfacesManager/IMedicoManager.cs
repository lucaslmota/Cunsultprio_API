﻿using Consultorio.Core.Shared.ModelViews.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.InterfacesManager
{
    public interface IMedicoManager
    {
        Task DeleteMedicoAsync(int id);

        Task<MedicoView> GetMedicoAsync(int id);

        Task<IEnumerable<MedicoView>> GetMedicosAsync();

        Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico);

        Task<MedicoView> UpdateMedicoAsync(AlteraMedico alteraMedico);
    }
}
