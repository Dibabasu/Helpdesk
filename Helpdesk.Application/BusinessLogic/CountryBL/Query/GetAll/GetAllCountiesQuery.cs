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

namespace Helpdesk.Application.BusinessLogic.CountryBL.Query.GetAll
{
    public class GetAllCountiesQuery : IRequest<CountryListModel>
    {
        public class Handler : IRequestHandler<GetAllCountiesQuery, CountryListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CountryListModel> Handle(
                GetAllCountiesQuery request,
                CancellationToken cancellationToken)
            {
                return new CountryListModel
                {
                    Countries = await _context.Set<Country>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<CountryModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}