using Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Command.Add;
using Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Query.GetAll;
using Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Query.GetById;
using Helpdesk.Models;
using Helpdesk.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Helpdesk.WebApi.References.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueCatagoryController : ApiController
    {
        // GET: api/<IssueCatagoryController>
        [HttpGet]
        public async Task<IssueCatagoryListModel> Get()
        {
            return await Mediator.Send(new GetAllIssueCatagoryQuery());
        }

        // GET api/<IssueCatagoryController>/5
        [HttpGet("{id}")]
        public async Task<IssueCatagoryModel> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetIssueCatagoryByIdQuery { Id = id });
            return vm;
        }

        // POST api/<IssueCatagoryController>
        [HttpPost]
        public async Task<Unit> Post([FromBody] CreateIssueCatagoryCommand request)
        {
            request.UserModel = await this.GetUserDetails("Ruru");
            return await Mediator.Send(request);
        }

        // PUT api/<IssueCatagoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IssueCatagoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}