using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.UserRoleBL.Command.Add
{
    public class CreateUserRoleValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleValidator()
        {
            RuleFor(x => x.UserRoleModel.Role).NotEmpty();
            RuleFor(x => x.UserRoleModel.UserId).NotEmpty();
        }
    }
}