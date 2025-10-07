using FluentValidation;
using Iventis.Domain.DTO;

namespace Iventis.Domain.Validators
{
    public class LocacaoValidator : AbstractValidator<LocacaoDTO>
    {
        public LocacaoValidator()
        {
            RuleFor(m => m.EntregadorId)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.MotoId)
            .NotEmpty()
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.DataInicio)
            .Must(data=> data != DateTime.MinValue)
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.DataTermino)
            .Must(data => data != DateTime.MinValue)
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.DataPrevisaoTermino)
            .Must(data => data != DateTime.MinValue)
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.Plano)
            .Must(plano => plano > 0)
            .WithMessage("{PropertyName} é de preenchimento Obrigatório");

        }
    }
}
