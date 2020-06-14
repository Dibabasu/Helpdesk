using Helpdesk.Application.BusinessLogic.UserBL.Query.GetByUserName;
using Helpdesk.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Helpdesk.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected virtual async Task<UserModel> GetUserDetails(string UserName)
        {
            var vm = await Mediator.Send(new GetUserByUserNameQuery { UserName = UserName });
            return vm;
        }
    }
}