using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.CountryBL.Command.Add
{
    public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryValidator()
        {
            RuleFor(x => x.CountryModel.CountryName).NotEmpty().MaximumLength(6);
            RuleFor(x => x.CountryModel.CountryName).NotEmpty();
        }
    }
}