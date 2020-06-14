using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Query.GetById
{
    public class GetIssueCatagoryByIdValidator : AbstractValidator<GetIssueCatagoryByIdQuery>
    {
        public GetIssueCatagoryByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}