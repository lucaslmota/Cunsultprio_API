using Bogus;
using Consultorio.Core.Shared.ModelViews.Telefone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.FakeData.TelefoneData
{
    public class NovoTelefoneFaker : Faker<NovoTelefone>
    {
        public NovoTelefoneFaker()
        {
            RuleFor(x => x.Numero, f => f.Person.Phone);
        }
    }
}
