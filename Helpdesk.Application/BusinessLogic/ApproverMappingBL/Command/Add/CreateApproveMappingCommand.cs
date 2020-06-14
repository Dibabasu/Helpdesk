using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Create;
using Helpdesk.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.ApproverMappingBL.Command.Add
{
    public class CreateApproveMappingCommand : IRequest
    {
        public ApprovalMappingCreateModel ApproverMappingModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateApproveMappingCommandHandler : IRequestHandler<CreateApproveMappingCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateApproveMappingCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateApproveMappingCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new ApproverMapping
                {
                    IssueSubCatagoryId = request.ApproverMappingModel.IssueSubCatagoryId,
                    IssueTypeId = request.ApproverMappingModel.IssueTypeId,
                    LocationId = request.ApproverMappingModel.LocationId,
                    StatusId = request.ApproverMappingModel.StatusId,
                    UserId = request.ApproverMappingModel.UserId,
                    CreatedBy = request.UserModel.UserName,
                    LastModifiedBy = request.UserModel.UserName
                };

                _context.Set<ApproverMapping>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}