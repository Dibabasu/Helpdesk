using AutoMapper;
using AutoMapper.QueryableExtensions;
using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.UserRoleBL.Query.GetById
{
    public class GetUserRoleByIdQuery : IRequest<UserRoleModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetUserRoleByIdQuery, UserRoleModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserRoleModel> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<UserRole>()
                 .Where(r => r.UserId == request.Id)
                 .ProjectTo<UserRoleModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UserRoleModel), request.Id);
                }

                return entity;
            }
        }
    }
}