using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using Helpdesk.Models.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.LocationBL.Command.Add
{
    public class CreateLocationCommand : IRequest
    {
        public LocationCreateModel LocationModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateLocationCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateLocationCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new Location
                {
                    CountryId = request.LocationModel.CountryId,
                    Description = request.LocationModel.Description,
                    LocationCode = request.LocationModel.LocationCode.ToUpper(),
                    LocationTypeId = request.LocationModel.LocationTypeId,
                    CreatedBy = request.UserModel.UserName,
                    LastModifiedBy = request.UserModel.UserName
                };

                _context.Set<Location>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}