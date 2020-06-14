using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.ApproverMappingBL.Query.GetById
{
    public class GetApproverMappingByIdValidator : AbstractValidator<GetApproverMappingByIdQuery>
    {
        public GetApproverMappingByIdValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();
        }
    }
}