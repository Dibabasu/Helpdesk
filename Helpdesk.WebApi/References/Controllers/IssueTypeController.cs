using Helpdesk.Application.BusinessLogic.IssueTypeBL.Command.Add;
using Helpdesk.Application.BusinessLogic.IssueTypeBL.Query;
using Helpdesk.Application.BusinessLogic.IssueTypeBL.Query.GetById;
using Helpdesk.Models;
using Helpdesk.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Helpdesk.WebApi.References.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueTypeController : ApiController
    {
        // GET: api/<IssueTypeController>
        [HttpGet]
        public async Task<IssueTypeListModel> Get()
        {
            return await Mediator.Send(new GetAllIssueTypeQuery());
        }

        // GET api/<IssueTypeController>/5
        [HttpGet("{id}")]
        public async Task<IssueTypeModel> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetIssueTypeByIdQuery { Id = id });
            return vm;
        }

        // POST api/<IssueTypeController>
        [HttpPost]
        public async Task Post([FromBody] CreateIssueTypeCommand request)
        {
            request.UserModel = await GetUserDetails("Ruru");
            await Mediator.Send(request);
        }

        // PUT api/<IssueTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IssueTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}