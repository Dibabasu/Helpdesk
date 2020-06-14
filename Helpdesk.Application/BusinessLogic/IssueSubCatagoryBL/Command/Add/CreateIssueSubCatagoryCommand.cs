using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using Helpdesk.Models.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Command.Add
{
    public class CreateIssueSubCatagoryCommand : IRequest
    {
        public IssueSubCatagoryCreateModel IssueSubCatagoryModel { get; set; }
        public UserModel UserModel { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateIssueSubCatagoryCommand, Unit>
        {
            private readonly IHelpdeskDbContext _context;

            public CreateCountryCommandHandler(IHelpdeskDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                CreateIssueSubCatagoryCommand request,
                CancellationToken cancellationToken)
            {
                var entity = new IssueSubCatagory
                {
                    IssueSubCatagoryCode = request.IssueSubCatagoryModel.IssueSubCatagoryCode.ToUpper(),
                    Description = request.IssueSubCatagoryModel.Description,
                    IssueCatagoryId = request.IssueSubCatagoryModel.IssueCatagoryId,
                    CreatedBy = request.UserModel.UserName,
                    LastModifiedBy = request.UserModel.UserName
                };

                _context.Set<IssueSubCatagory>().Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}