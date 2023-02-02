using Consultorio.Core.Shared.ModelViews.Especialidade;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.Validator
{
    public class ReferenciaEspecialidadeValidator : AbstractValidator<NovaEspecialidade>
    {
        public ReferenciaEspecialidadeValidator()
        {
            RuleFor(p => p.Descricao).NotEmpty().NotNull().MinimumLength(3).MaximumLength(100).WithMessage("O nome não pode ser vazio.");
        }
    }
}
