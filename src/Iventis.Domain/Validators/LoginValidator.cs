using FluentValidation;
using Iventis.Domain.DTO;

namespace Iventis.Domain.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email)
              .NotEmpty()
              .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(l => l.Senha)
              .NotEmpty()
              .WithMessage("{PropertyName} é de preenchimento Obrigatório");
        }
    }
}
