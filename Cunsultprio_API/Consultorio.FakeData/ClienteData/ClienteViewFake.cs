using Bogus;
using Bogus.Extensions.Brazil;
using Consultorio.Core.Shared.ModelViews.Cliente;
using Consultorio.FakeData.EnderecoData;
using Consultorio.FakeData.TelefoneData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.FakeData.ClienteData
{
    public class ClienteViewFake : Faker<ClienteView>
    {
        public ClienteViewFake()
        {
            var id = new Faker().Random.Number(1, 999999);
            RuleFor(x => x.Id, f => id);
            RuleFor(x => x.Nome, f => f.Person.FullName);
            RuleFor(x => x.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(x => x.Documento, f => f.Person.Cpf());
            RuleFor(x => x.Criacao, f => f.Date.Past());
            RuleFor(x => x.UltimaAtualizacao, f => f.Date.Past());
            RuleFor(p => p.DataNascimento, f => f.Date.Past());
            RuleFor(x => x.Telefones, f => new TelefoneViewFaker().Generate(3));
            RuleFor(p => p.Endereco, f => new EnderecoViewFaker().Generate());
        }
    }
}
