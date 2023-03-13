using ConsultorioCore.Domain;
using ConsultorioData.Context;
using ConsultorioManager.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioData.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ConsultorioContext _context;

        public MedicoRepository(ConsultorioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await _context.Medicos
              .Include(p => p.Especialidades)
              .AsNoTracking().ToListAsync();
        }

        public async Task<Medico> GetMedicoAsync(int id)
        {
            return await _context.Medicos
                .Include(p => p.Especialidades)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            //await InsertMedicoEspecilidades(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        private async Task InsertMedicoEspecilidades(Medico medico)
        {
            foreach (var especialidade in medico.Especialidades)
            {
                var especialidadeConsultada = await _context.Especialidades.AsNoTracking().FirstAsync(p => p.Id == especialidade.Id);
                _context.Entry(especialidade).CurrentValues.SetValues(especialidadeConsultada);
            }
        }

        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoConsultado = await _context.Medicos
                                        .Include(p => p.Especialidades)
                                        .SingleOrDefaultAsync(p => p.Id == medico.Id);

            medicoConsultado.Nome = medico.Nome;
            medicoConsultado.CRM = medico.CRM;
            
            foreach(var item in medicoConsultado.Especialidades)
            {
                foreach(var item2 in medico.Especialidades)
                {
                    item.Descricao = item2.Descricao;
                }
                var especialidade = await _context.Especialidades.SingleOrDefaultAsync(x => x.Id == item.Id);
                medicoConsultado.Especialidades.Add(especialidade);
            }

            if (medicoConsultado == null)
            {
                return null;
            }
            
            await _context.SaveChangesAsync();
            return medicoConsultado;
        }

        //private async Task UpdateMedicoEspecialidades( Medico medicoConsultado)
        //{
        //    //medicoConsultado.Especialidades.Clear();
        //    //int especialidadeConsultada? = null;
        //    foreach (var especialidade in medicoConsultado.Especialidades)
        //    {
        //         var especialidadeConsultada = Convert.ToInt32(await _context.Especialidades.FindAsync(especialidade.Id));
        //        //medicoConsultado.Especialidades.Add(especialidadeConsultada);
        //    }
        //    //return especialidadeConsultada;
        //}

        public async Task DeleteMedicoAsync(int id)
        {
            var medicoConsultado = await _context.Medicos.FindAsync(id);
            _context.Medicos.Remove(medicoConsultado);
            await _context.SaveChangesAsync();
        }
    }
}
