using FluentValidation;

namespace Iventis.Domain.Services
{
    public class BaseService
    {
        protected (bool,List<string>) Validate<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> 
        {
            var errorMessages = new List<string>();

            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return (true,new List<string>());

            errorMessages = validator.Errors.Select(x => x.ErrorMessage).ToList();

            return (false, errorMessages);
        }
    }
}
