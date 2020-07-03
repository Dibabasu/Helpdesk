using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.UserBL.Command.Add
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstMidName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DepartmentName).NotEmpty().MaximumLength(15);
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Division).NotEmpty().MaximumLength(10);
        }
    }
}