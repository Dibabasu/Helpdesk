using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Query.GetById
{
    public class GetIssueSubCatagoryByIdValidator : AbstractValidator<GetIssueSubCatagoryByIdQuery>
    {
        public GetIssueSubCatagoryByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}