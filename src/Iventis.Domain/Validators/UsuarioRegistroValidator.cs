using FluentValidation;
using Iventis.Domain.DTO;

namespace Iventis.Domain.Validators
{
    public class UsuarioRegistroValidator : AbstractValidator<UsuarioRegistroDTO>
    {
        public UsuarioRegistroValidator()
        {
            RuleFor(l => l.Nome)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(l => l.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(l => l.Senha)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");
        }
    }
}
