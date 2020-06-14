using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using Helpdesk.Models.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.LocationTypeBL.Command.Add
{
    public class CreateLocationTypeCommand : IRequest
    {
        public LocationTypeCreateModel LocationTypeModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateLocationTypeCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateLocationTypeCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new LocationType
                {
                    LocationTypeCode = request.LocationTypeModel.LocationTypeCode.ToUpper(),
                    Description = request.LocationTypeModel.Description,
                    CreatedBy = "Admin",
                    LastModifiedBy = "Admin"
                };

                _context.Set<LocationType>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}