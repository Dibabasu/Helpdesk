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

namespace Helpdesk.Application.BusinessLogic.StatusBL.Query.GetbyCode
{
    public class GetStatusByCodeQuery : IRequest<StatusModel>
    {
        public String StatusCode { get; set; }

        public class Handler : IRequestHandler<GetStatusByCodeQuery, StatusModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<StatusModel> Handle(
                GetStatusByCodeQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<Status>()
                 .Where(r => r.StatusCode == request.StatusCode.ToUpper())
                 .ProjectTo<StatusModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(LocationModel), request.StatusCode);
                }

                return entity;
            }
        }
    }
}