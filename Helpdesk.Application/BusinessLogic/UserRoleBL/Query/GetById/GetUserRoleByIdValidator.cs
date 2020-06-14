using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.UserRoleBL.Query.GetById
{
    public class GetUserRoleByIdValidator : AbstractValidator<GetUserRoleByIdQuery>
    {
        public GetUserRoleByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}