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

namespace Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Query.GetAll
{
    public class GetAllIssueCatagoryQuery : IRequest<IssueCatagoryListModel>
    {
        public class Handler : IRequestHandler<GetAllIssueCatagoryQuery, IssueCatagoryListModel>
        {
            private readonly IHelpdeskDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IHelpdeskDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IssueCatagoryListModel> Handle(
                GetAllIssueCatagoryQuery request,
                CancellationToken cancellationToken)
            {
                return new IssueCatagoryListModel
                {
                    IssueCatagories = await _context.Set<IssueCatagory>()
                    .Where(x => x.IsDeleted == false)
                    .ProjectTo<IssueCatagoryModel>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                };
            }
        }
    }
}