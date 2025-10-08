using FluentValidation;
using Iventis.Domain.DTO;

namespace Iventis.Domain.Validators
{
    public class LocacaoValidator : AbstractValidator<LocacaoDTO>
    {
        public LocacaoValidator()
        {
            RuleFor(m => m.IdentificadorEntregador)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.IdentificadorMoto)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.DtInicio)
            .Must(data=> data != DateTime.MinValue)
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.DtTermino)
            .Must(data => data != DateTime.MinValue)
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.DtPrevisaoTermino)
            .Must(data => data != DateTime.MinValue)
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.Plano)
            .Must(plano => plano > 0)
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

        }
    }
}
