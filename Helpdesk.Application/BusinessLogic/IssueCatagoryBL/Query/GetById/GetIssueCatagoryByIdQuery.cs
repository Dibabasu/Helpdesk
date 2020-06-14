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

namespace Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Query.GetById
{
    public class GetIssueCatagoryByIdQuery : IRequest<IssueCatagoryModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetIssueCatagoryByIdQuery, IssueCatagoryModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IssueCatagoryModel> Handle(
                GetIssueCatagoryByIdQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<IssueCatagory>()
                 .Where(r => r.Id == request.Id)
                 .ProjectTo<IssueCatagoryModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(IssueCatagoryModel), request.Id);
                }

                return entity;
            }
        }
    }
}