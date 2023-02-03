using ConsultorioCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioCore.Domain
{
    public class Cliente
    {
        public int Id{ get; set; }
        public string Nome{ get; set; }
        public DateTime DataNascimento { get; set; }
        public ESexo Sexo { get; set; }
        public ICollection<Telefone> Telefone { get; set; } // 1 para muitos
        public string Documento{ get; set; }
        public DateTime Criacao{ get; set; }
        public DateTime? UltimaAtualizacao{ get; set; }

        public Endereco Endereco { get; set; } // 1 para 1
    }
}
