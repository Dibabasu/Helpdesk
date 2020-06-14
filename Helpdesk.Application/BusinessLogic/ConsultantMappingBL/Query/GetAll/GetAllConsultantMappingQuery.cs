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

namespace Helpdesk.Application.BusinessLogic.ConsultantMappingBL.Query.GetAll
{
    public class GetAllConsultantMappingQuery : IRequest<ConsultantMappingListModel>
    {
        public class Handler : IRequestHandler<GetAllConsultantMappingQuery, ConsultantMappingListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ConsultantMappingListModel> Handle(
                GetAllConsultantMappingQuery request,
                CancellationToken cancellationToken)
            {
                return new ConsultantMappingListModel
                {
                    ConsultantMappings = await _context.Set<ConsultantMapping>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<ConsultantMappingModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}