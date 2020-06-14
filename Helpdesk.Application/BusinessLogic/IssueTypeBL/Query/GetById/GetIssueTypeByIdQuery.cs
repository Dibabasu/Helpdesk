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

namespace Helpdesk.Application.BusinessLogic.IssueTypeBL.Query.GetById
{
    public class GetIssueTypeByIdQuery : IRequest<IssueTypeModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetIssueTypeByIdQuery, IssueTypeModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IssueTypeModel> Handle(
                GetIssueTypeByIdQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<IssueType>()
                 .Where(r => r.Id == request.Id)
                 .ProjectTo<IssueTypeModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(IssueTypeModel), request.Id);
                }

                return entity;
            }
        }
    }
}