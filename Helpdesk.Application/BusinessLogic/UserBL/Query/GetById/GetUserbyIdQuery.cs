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

namespace Helpdesk.Application.BusinessLogic.UserBL.Query.GetById
{
    public class GetUserbyIdQuery : IRequest<UserModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetUserbyIdQuery, UserModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserModel> Handle(GetUserbyIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<User>()
                 .Where(r => r.UserId == request.Id)
                 .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UserModel), request.Id);
                }

                return entity;
            }
        }
    }
}