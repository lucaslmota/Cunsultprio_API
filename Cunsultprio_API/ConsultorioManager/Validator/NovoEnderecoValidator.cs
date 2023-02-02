using Consultorio.Core.Shared.ModelViews.Endereco;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.Validator
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
    {
        public NovoEnderecoValidator() 
        {
            RuleFor(x => x.Cidade).NotEmpty().NotNull().MaximumLength(80);
        }
    }
}
