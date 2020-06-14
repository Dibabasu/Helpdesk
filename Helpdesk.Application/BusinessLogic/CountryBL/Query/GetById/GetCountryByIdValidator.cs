using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.CountryBL.Query.GetById
{
    internal class GetCountryByIdValidator : AbstractValidator<GetCountyByIdQuery>
    {
        public GetCountryByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}