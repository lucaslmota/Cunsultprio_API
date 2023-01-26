﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Core.Shared.ModelViews
{
    /// <summary>
    /// Objeto usado para uma nova inserção de um novo cliente
    /// </summary>
    public class NovoCliente
    {
        /// <summary>
        /// Nome do Cliente
        /// </summary>
        /// <example> Lucas Lima Mota</example>
        public string Nome { get; set; }
        /// <summary>
        /// Data de Nascimento
        /// </summary>
        /// <example>23/04/1993</example>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Sexo do Cliente
        /// </summary>
        /// <example>M</example>
        public string Sexo { get; set; }
        /// <summary>
        /// Telefone do cliente
        /// </summary>
        /// <example>88999999999</example>
        public string Telefone { get; set; }
        /// <summary>
        /// Documento
        /// </summary>
        /// <example>05769313201</example>
        public string Documento { get; set; }
        /// <summary>
        /// Novo endereço do cliente
        /// </summary>
        public NovoEndereco Endereco { get; set; }
    }
}
