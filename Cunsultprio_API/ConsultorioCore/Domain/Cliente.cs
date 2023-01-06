﻿using System;
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
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Documento{ get; set; }
        public DateTime Criacao{ get; set; }
        public DateTime? UltimaAtualizacao{ get; set; }
    }
}