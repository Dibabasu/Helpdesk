using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.UserBL.Command.Add
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.User.FirstMidName).NotEmpty();
            RuleFor(x => x.User.LastName).NotEmpty();
            RuleFor(x => x.User.DepartmentName).NotEmpty().MaximumLength(15);
            RuleFor(x => x.User.UserName).NotEmpty();
            RuleFor(x => x.User.Division).NotEmpty().MaximumLength(10);
        }
    }
}