using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Command.Add
{
    internal class CreateIssueSubCatagoryValidator : AbstractValidator<CreateIssueSubCatagoryCommand>
    {
        public CreateIssueSubCatagoryValidator()
        {
            RuleFor(x => x.IssueSubCatagoryModel.Description).NotEmpty();
            RuleFor(x => x.IssueSubCatagoryModel.IssueCatagoryId).NotEmpty();
            RuleFor(x => x.IssueSubCatagoryModel.IssueSubCatagoryCode).NotEmpty().MaximumLength(6);
        }
    }
}