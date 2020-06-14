using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Create;
using Helpdesk.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.ConsultantMappingBL.Command.Add
{
    public class CreateConsultantMappingCommand : IRequest
    {
        public ConsultantMappingCreateModel Consultant { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateApproveMappingCommandHandler : IRequestHandler<CreateConsultantMappingCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateApproveMappingCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateConsultantMappingCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new ConsultantMapping
                {
                    LastModifiedBy = request.UserModel.UserName,
                    CreatedBy = request.UserModel.UserName,
                    IssueSubCatagoryId = request.Consultant.IssueSubCatagoryId,
                    IssueTypeId = request.Consultant.IssueTypeId,
                    LocationId = request.Consultant.LocationId,
                    UserId = request.Consultant.UserId
                };

                _context.Set<ConsultantMapping>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}