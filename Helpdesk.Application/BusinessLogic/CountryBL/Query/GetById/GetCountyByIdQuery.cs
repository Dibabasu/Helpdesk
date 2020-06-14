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

namespace Helpdesk.Application.BusinessLogic.CountryBL.Query.GetById
{
    public class GetCountyByIdQuery : IRequest<CountryModel>
    {
        public Guid Id { get; set; }

        public class Handler : IRequestHandler<GetCountyByIdQuery, CountryModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CountryModel> Handle(
                GetCountyByIdQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.Set<Country>()
                 .Where(r => r.Id == request.Id)
                 .ProjectTo<CountryModel>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(CountryModel), request.Id);
                }

                return entity;
            }
        }
    }
}