using FluentValidation;

namespace Helpdesk.Application.BusinessLogic.ApproverMappingBL.Command.Add
{
    public class CreateApproveMappingValidator : AbstractValidator<CreateApproveMappingCommand>
    {
        public CreateApproveMappingValidator()
        {
            RuleFor(x => x.ApproverMappingModel.StatusId).NotEmpty();
            RuleFor(x => x.ApproverMappingModel.UserId).NotEmpty();
            RuleFor(x => x.ApproverMappingModel.IssueSubCatagoryId).NotEmpty();
            RuleFor(x => x.ApproverMappingModel.IssueTypeId).NotEmpty();
            RuleFor(x => x.ApproverMappingModel.LocationId).NotEmpty();
        }
    }
}