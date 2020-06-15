using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using Helpdesk.Models.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.StatusBL.Command.Add
{
    public class CreateStatusCommand : IRequest
    {
        public StatusCreateModel StatusModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateStatusCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;


            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateStatusCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new Status
                {
                    Description = request.StatusModel.Description,
                    StatusCode = request.StatusModel.StatusCode.ToUpper(),
                    CreatedBy = request.UserModel.UserName,
                    LastModifiedBy = request.UserModel.UserName
                };

                _context.Set<Status>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}