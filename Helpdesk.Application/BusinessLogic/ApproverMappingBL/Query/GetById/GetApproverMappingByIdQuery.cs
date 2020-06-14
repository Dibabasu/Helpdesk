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

namespace Helpdesk.Application.BusinessLogic.ApproverMappingBL.Query.GetById
{
    public class GetApproverMappingByIdQuery : IRequest<ApproverMappingModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetApproverMappingByIdQuery, ApproverMappingModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ApproverMappingModel> Handle(
                GetApproverMappingByIdQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<ApproverMapping>()
                 .Where(r => r.Id == request.Id)
                 .ProjectTo<ApproverMappingModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(ApproverMappingModel), request.Id);
                }

                return entity;
            }
        }
    }
}