using Consultorio.Core.Shared.ModelViews.Cliente;
using ConsultorioCore.Domain;
using FluentValidation;
using System;

namespace ConsultorioManager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(100).WithMessage("O nome não pode ser vazio.");
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130)).WithMessage("A data de nascimento não pode ser vazia");
            RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(15);
            RuleFor(x => x.Telefone).NotNull().NotEmpty();
            RuleFor(x => x.Sexo).NotNull();
            RuleFor(x => x.Endereco).SetValidator(new NovoEnderecoValidator());
        }
    }
}
