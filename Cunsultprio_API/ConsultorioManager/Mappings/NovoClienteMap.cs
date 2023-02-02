using AutoMapper;
using Consultorio.Core.Shared.ModelViews.Cliente;
using Consultorio.Core.Shared.ModelViews.Endereco;
using Consultorio.Core.Shared.ModelViews.Telefone;
using ConsultorioCore.Domain;
using System;

namespace ConsultorioManager.Mappings
{
    public class NovoClienteMap : Profile
    {
        public NovoClienteMap()
        {
            CreateMap<NovoCliente, Cliente>()
            .ForMember(destino => destino.Criacao, opcao => opcao.MapFrom(x => DateTime.Now))
            .ForMember(destino => destino.DataNascimento, opcao => opcao.MapFrom(x => x.DataNascimento.Date));

            CreateMap<NovoEndereco, Endereco>();
            CreateMap<NovoTelefone, Telefone>();
        }
    }
}
