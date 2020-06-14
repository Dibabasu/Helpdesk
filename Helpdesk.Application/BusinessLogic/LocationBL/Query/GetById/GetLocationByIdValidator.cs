using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.LocationBL.Query.GetById
{
    public class GetLocationByIdValidator : AbstractValidator<GetLocationByIdQuery>
    {
        public GetLocationByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}