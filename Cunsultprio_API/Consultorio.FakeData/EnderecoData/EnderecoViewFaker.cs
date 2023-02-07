﻿using Bogus;
using Consultorio.Core.Shared.ModelViews.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.FakeData.EnderecoData
{
    public class EnderecoViewFaker : Faker<EnderecoView>
    {
        public EnderecoViewFaker()
        {
            RuleFor(p => p.Numero, f => f.Address.BuildingNumber());
            RuleFor(p => p.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
            RuleFor(p => p.Cidade, f => f.Address.City());
            RuleFor(p => p.Estado, f => f.PickRandom<EstadoView>());
            RuleFor(p => p.Logradouro, f => f.Address.StreetName());
            RuleFor(p => p.Complemento, f => f.Lorem.Sentence(20));
        }
    }
}
