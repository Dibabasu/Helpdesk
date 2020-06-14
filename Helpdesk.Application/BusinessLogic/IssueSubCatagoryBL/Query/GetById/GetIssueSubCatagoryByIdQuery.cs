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

namespace Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Query.GetById
{
    public class GetIssueSubCatagoryByIdQuery : IRequest<IssueSubCatagoryModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetIssueSubCatagoryByIdQuery, IssueSubCatagoryModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IssueSubCatagoryModel> Handle(
                GetIssueSubCatagoryByIdQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<IssueSubCatagory>()
                 .Where(r => r.Id == request.Id)
                 .ProjectTo<IssueSubCatagoryModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(IssueSubCatagoryModel), request.Id);
                }

                return entity;
            }
        }
    }
}