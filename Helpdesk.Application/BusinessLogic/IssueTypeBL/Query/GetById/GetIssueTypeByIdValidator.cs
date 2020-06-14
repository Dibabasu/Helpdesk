using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.IssueTypeBL.Query.GetById
{
    public class GetIssueTypeByIdValidator : AbstractValidator<GetIssueTypeByIdQuery>
    {
        public GetIssueTypeByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}