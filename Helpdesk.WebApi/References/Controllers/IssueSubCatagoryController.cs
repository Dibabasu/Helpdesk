using Helpdesk.Application.BusinessLogic.IssueCatagoryBL.Query.GetAll;
using Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Command.Add;
using Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Query.GetAll;
using Helpdesk.Application.BusinessLogic.IssueSubCatagoryBL.Query.GetById;
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
    public class IssueSubCatagoryController : ApiController
    {
        // GET: api/<IssueSubCatagoryController>
        [HttpGet]
        public async Task<IssueSubCatagoryListModel> Get()
        {
            return await Mediator.Send(new GetAllIssueSubCatagoryQuery());
        }

        // GET api/<IssueSubCatagoryController>/5
        [HttpGet("{id}")]
        public async Task<IssueSubCatagoryModel> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetIssueSubCatagoryByIdQuery { Id = id });
            return vm;
        }

        // POST api/<IssueSubCatagoryController>
        [HttpPost]
        public async Task<Unit> Post([FromBody]CreateIssueSubCatagoryCommand request)
        {
            request.UserModel = await this.GetUserDetails("Ruru");
            return await Mediator.Send(request);
        }

        // PUT api/<IssueSubCatagoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IssueSubCatagoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}