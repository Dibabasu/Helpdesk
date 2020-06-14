using Helpdesk.Application.Interface;

using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using Helpdesk.Models.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.IssueTypeBL.Command.Add
{
    public class CreateIssueTypeCommand : IRequest
    {
        public IssueTypeCreateModel IssueTypeModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateIssueTypeCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateIssueTypeCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new IssueType
                {
                    IssueTypeCode = request.IssueTypeModel.IssueTypeCode.ToUpper(),
                    Description = request.IssueTypeModel.Description,
                    CreatedBy = request.UserModel.UserName,
                    LastModifiedBy = request.UserModel.UserName,
                };

                _context.Set<IssueType>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}