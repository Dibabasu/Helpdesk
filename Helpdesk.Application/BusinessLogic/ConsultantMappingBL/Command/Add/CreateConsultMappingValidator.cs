using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.ConsultantMappingBL.Command.Add
{
    public class CreateConsultMappingValidator : AbstractValidator<CreateConsultantMappingCommand>
    {
        public CreateConsultMappingValidator()
        {
            RuleFor(x => x.Consultant.IssueSubCatagoryId);
            RuleFor(x => x.Consultant.IssueTypeId);
            RuleFor(x => x.Consultant.LocationId);
            RuleFor(x => x.Consultant.UserId);
        }
    }
}