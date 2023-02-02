using Consultorio.Core.Shared.ModelViews.Cliente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioManager.Validator
{
    public class AlteraClienteValidator : AbstractValidator<AlterarCliente>
    {
        public AlteraClienteValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NovoClienteValidator());
            
        }

       
    }
}
