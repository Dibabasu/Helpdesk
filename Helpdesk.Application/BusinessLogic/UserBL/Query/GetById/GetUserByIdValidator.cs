using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.UserBL.Query.GetById
{
    public class GetUserByIdValidator : AbstractValidator<GetUserbyIdQuery>
    {
        public GetUserByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}