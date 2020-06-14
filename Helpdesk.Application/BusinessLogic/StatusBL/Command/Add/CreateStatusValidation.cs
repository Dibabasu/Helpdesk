using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.StatusBL.Command.Add
{
    public class CreateStatusValidation : AbstractValidator<CreateStatusCommand>
    {
        public CreateStatusValidation()
        {
            RuleFor(x => x.StatusModel.Description).NotEmpty();
            RuleFor(x => x.StatusModel.StatusCode).NotEmpty().MaximumLength(6);
        }
    }
}