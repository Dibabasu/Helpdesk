using AutoMapper;
using AutoMapper.QueryableExtensions;
using Helpdesk.Application.Exceptions;
using Helpdesk.Application.Interface;
using Helpdesk.Domain.Entities;
using Helpdesk.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpdesk.Application.BusinessLogic.UserBL.Query.GetByUserName
{
   public class GetUserByUserNameQuery : IRequest<UserModel>
    {
        public String UserName { get; set; }

        public class Handler : IRequestHandler<GetUserByUserNameQuery, UserModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserModel> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Set<User>()
                 .Where(r => r.AdAccount.UserName == request.UserName)
                 .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(UserModel), request.UserName);
                }

                return entity;
            }
        }
    }
}