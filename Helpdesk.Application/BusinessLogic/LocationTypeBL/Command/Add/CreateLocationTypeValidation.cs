using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.LocationTypeBL.Command.Add
{
    internal class CreateLocationTypeValidation : AbstractValidator<CreateLocationTypeCommand>
    {
        public CreateLocationTypeValidation()
        {
            RuleFor(x => x.LocationTypeModel.Description).NotEmpty();
            RuleFor(x => x.LocationTypeModel.LocationTypeCode).NotEmpty().MaximumLength(6);
        }
    }
}