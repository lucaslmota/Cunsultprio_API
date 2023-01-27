using Consultorio.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.Validator
{
    public class NovoTelefoneValidator : AbstractValidator<NovoTelefone>
    {
        public NovoTelefoneValidator()
        {
            RuleFor(x => x.Numero).Matches("[2-9][0-9]{10}").WithMessage("O número de telefone deve seguir o padrão brasileiro");
        }
    }
}
