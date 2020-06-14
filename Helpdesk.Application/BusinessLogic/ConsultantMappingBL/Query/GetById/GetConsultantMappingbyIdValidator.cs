using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.ConsultantMappingBL.Query.GetById
{
    public class GetConsultantMappingbyIdValidator : AbstractValidator<GetConsultantMappingByIdQuery>
    {
        public GetConsultantMappingbyIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}