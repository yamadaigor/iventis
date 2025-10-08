using FluentValidation;
using Iventis.Domain.DTO;

namespace Iventis.Domain.Validators
{
    public class EntregadorValidator : AbstractValidator<EntregadorDTO>
    {
        public EntregadorValidator()
        {
            RuleFor(m => m.Identificador)
             .NotEmpty()
             .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.Nome)
             .NotEmpty()
             .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.Cnpj)
             .NotEmpty()
             .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.DataNascimento)
             .NotEmpty()
             .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.NumeroCnh)
             .NotEmpty()
             .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.TipoCnh)
             .NotEmpty()
             .WithMessage("{PropertyName} é de preenchimento Obrigatório");

            RuleFor(m => m.ImagemCnh)
             .NotEmpty()
             .WithMessage("{PropertyName} é de preenchimento Obrigatório");
        }
    }
}
