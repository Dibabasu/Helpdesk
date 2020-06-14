using Helpdesk.Application.BusinessLogic.StatusBL.Command.Add;
using Helpdesk.Application.BusinessLogic.StatusBL.Query.GetAll;
using Helpdesk.Application.BusinessLogic.StatusBL.Query.GetbyCode;
using Helpdesk.Application.BusinessLogic.StatusBL.Query.GetById;
using Helpdesk.Models;
using Helpdesk.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Helpdesk.WebApi.References.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ApiController
    {
        // GET: api/<StatusController>
        [HttpGet]
        public async Task<ActionResult<StatusListModel>> Get()
        {
            return await Mediator.Send(new GetAllStatusQuery());
        }

        // GET api/<StatusController>/0000-00000-00000
        [HttpGet("{id:guid}")]
        public async Task<StatusModel> Get(Guid Id)
        {
            var vm = await Mediator.Send(new GetStatusbyIdQuery { Id = Id });
            return vm;
        }

        // GET api/<StatusController>/New
        [HttpGet("{StatusCode}")]
        public async Task<StatusModel> Get(String StatusCode)
        {
            var vm = await Mediator.Send(new GetStatusByCodeQuery { StatusCode = StatusCode });
            return vm;
        }

        // POST api/<StatusController>
        [HttpPost]
        public async Task<Unit> Post([FromBody] CreateStatusCommand request)
        {
            request.UserModel = await this.GetUserDetails("Ruru");
            return await Mediator.Send(request);
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}