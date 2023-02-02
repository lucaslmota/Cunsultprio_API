using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioCore.Domain
{
    public class Especialidade
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Medico> Medicos { get; set; }
    }
}
