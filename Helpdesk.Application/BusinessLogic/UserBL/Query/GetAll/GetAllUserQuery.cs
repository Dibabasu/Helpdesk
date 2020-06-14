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

namespace Helpdesk.Application.BusinessLogic.UserBL.Query.GetAll
{
    public class GetAllUserQuery : IRequest<UserListModel>
    {
        public class Handler : IRequestHandler<GetAllUserQuery, UserListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserListModel> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                return new UserListModel
                {
                    Users = await _context.Set<User>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}