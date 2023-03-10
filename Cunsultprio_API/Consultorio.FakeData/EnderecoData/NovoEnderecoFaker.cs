using Bogus;
using Consultorio.Core.Shared.ModelViews.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.FakeData.EnderecoData
{
    public class NovoEnderecoFaker : Faker<NovoEndereco>
    {
        public NovoEnderecoFaker()
        {
            RuleFor(x => x.Numero, f => f.Address.BuildingNumber());
            RuleFor(x => x.CEP, f => (f.Address.ZipCode().Replace("-", "")));
            RuleFor(x => x.Cidade, f => f.Address.City());
            RuleFor(x => x.Estado, f => f.PickRandom<EstadoView>());
            RuleFor(x => x.Logradouro, f => f.Address.StreetName());
            RuleFor(x => x.Complemento, f => f.Lorem.Sentence(20));
        }
    }
}
