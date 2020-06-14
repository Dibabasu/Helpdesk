using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Command.Add
{
    public class CreateIssueCatagoryValidator : AbstractValidator<CreateIssueCatagoryCommand>
    {
        public CreateIssueCatagoryValidator()
        {
            RuleFor(x => x.IssueCatagoryModel.Description).NotEmpty();
            RuleFor(x => x.IssueCatagoryModel.IssueCatagoryCode).NotEmpty().MaximumLength(6);
        }
    }
}