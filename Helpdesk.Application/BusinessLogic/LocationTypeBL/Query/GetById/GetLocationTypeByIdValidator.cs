using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.LocationTypeBL.Query.GetById
{
    internal class GetLocationTypeByIdValidator : AbstractValidator<GetLocationTypeByIdQuery>
    {
        public GetLocationTypeByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}