using AutoMapper;
using Consultorio.Core.Shared.ModelViews;
using ConsultorioCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.Mappings
{
    public class AlterarClienteMap : Profile
    {
        public AlterarClienteMap()
        {
            CreateMap<AlterarCliente, Cliente>()
                .ForMember(destino => destino.UltimaAtualizacao, opcao => opcao.MapFrom(x => DateTime.Now))
                .ForMember(destino => destino.DataNascimento, opcao => opcao.MapFrom(x => x.DataNascimento.Date));
        }
    }
}
