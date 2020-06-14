using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Model.Create;
using Helpdesk.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.CountryBL.Command.Add
{
    public class CreateCountryCommand : IRequest
    {
        public CountryCreateModel CountryModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateCountryCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new Country
                {
                    CountryCode = request.CountryModel.CountryCode.ToUpper(),
                    Description = request.CountryModel.CountryName,
                    CreatedBy = request.UserModel.UserName,
                    LastModifiedBy = request.UserModel.UserName,
                };

                _context.Set<Country>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}