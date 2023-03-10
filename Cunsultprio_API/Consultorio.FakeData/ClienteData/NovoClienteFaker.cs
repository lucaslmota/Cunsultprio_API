using Bogus;
using Bogus.Extensions.Brazil;
using Consultorio.Core.Shared.ModelViews.Cliente;
using Consultorio.Core.Shared.ModelViews.Telefone;
using Consultorio.FakeData.EnderecoData;
using Consultorio.FakeData.TelefoneData;

namespace Consultorio.FakeData.ClienteData
{
    public class NovoClienteFaker : Faker<NovoCliente>
    {
        public NovoClienteFaker()
        {
            RuleFor(x => x.Nome, f => f.Person.FullName);
            RuleFor(x => x.Sexo, f => f.PickRandom<SexoView>());
            RuleFor(x => x.Documento, f => f.Person.Cpf());
            RuleFor(x => x.DataNascimento, f => f.Date.Past());
            RuleFor(x => x.Telefone, f => new NovoTelefoneFaker().Generate(3));
            RuleFor(x => x.Endereco, f => new NovoEnderecoFaker().Generate());
        }
    }
}
