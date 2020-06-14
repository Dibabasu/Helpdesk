using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.LocationBL.Command.Add
{
    public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationValidator()
        {
            RuleFor(x => x.LocationModel.LocationTypeId).NotEmpty();
            RuleFor(x => x.LocationModel.CountryId).NotEmpty();
            RuleFor(x => x.LocationModel.Description).NotEmpty();
            RuleFor(x => x.LocationModel.LocationCode).NotEmpty().MaximumLength(6);
        }
    }
}