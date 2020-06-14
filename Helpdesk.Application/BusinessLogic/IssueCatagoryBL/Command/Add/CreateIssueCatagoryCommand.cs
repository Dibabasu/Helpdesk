using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Command.Add
{
    public class CreateIssueCatagoryCommand : IRequest
    {
        public IssueCatagoryModel IssueCatagoryModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateIssueCatagoryCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateIssueCatagoryCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new IssueCatagory
                {
                    IssueCatagoryCode = request.IssueCatagoryModel.IssueCatagoryCode.ToUpper(),
                    Description = request.IssueCatagoryModel.Description,
                    CreatedBy = request.UserModel.UserName,
                    LastModifiedBy = request.UserModel.UserName,
                };

                _context.Set<IssueCatagory>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}