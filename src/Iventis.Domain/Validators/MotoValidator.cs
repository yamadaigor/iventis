using FluentValidation;
using Iventis.Domain.Entities;

namespace Iventis.Domain.Validators
{
    public class MotoValidator : AbstractValidator<Moto>
    {
        public MotoValidator()
        {
            RuleFor(m => m.Identificador)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.Ano)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.Modelo)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.Placa)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");
        }
    }
}
