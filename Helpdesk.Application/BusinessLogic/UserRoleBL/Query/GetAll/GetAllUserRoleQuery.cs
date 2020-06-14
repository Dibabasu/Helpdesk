using AutoMapper;
using AutoMapper.QueryableExtensions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.UserRoleBL.Query.GetAll
{
    public class GetAllUserRoleQuery : IRequest<UserRoleListModel>
    {
        public class Handler : IRequestHandler<GetAllUserRoleQuery, UserRoleListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserRoleListModel> Handle(GetAllUserRoleQuery request, CancellationToken cancellationToken)
            {
                return new UserRoleListModel
                {
                    UserRoles = await _context.Set<UserRole>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<UserRoleModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}