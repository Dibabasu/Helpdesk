using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.IssueTypeBL.Command.Add
{
    internal class CreateIssueTypeValidator : AbstractValidator<CreateIssueTypeCommand>
    {
        public CreateIssueTypeValidator()
        {
            RuleFor(x => x.IssueTypeModel.Description).NotEmpty();
            RuleFor(x => x.IssueTypeModel.IssueTypeCode).NotEmpty().MaximumLength(6);
        }
    }
}