using Helpdesk.Application.BusinessLogic.CountryBL.Command.Add;
using Helpdesk.Application.BusinessLogic.CountryBL.Command.Remove;
using Helpdesk.Application.BusinessLogic.CountryBL.Query.GetAll;
using Helpdesk.Application.BusinessLogic.CountryBL.Query.GetById;
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
    public class CountyController : ApiController
    {
        // GET: api/<CountyController>
        [HttpGet]
        public async Task<ActionResult<CountryListModel>> Get()
        {
            return await Mediator.Send(new GetAllCountiesQuery());
        }

        // GET api/<CountyController>/5
        [HttpGet("{id}")]
        public async Task<CountryModel> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetCountyByIdQuery { Id = id });
            return vm;
        }

        // POST api/<CountyController>
        [HttpPost]
        public async Task<ActionResult<Unit>> Post([FromBody] CreateCountryCommand request)
        {
            request.UserModel = await this.GetUserDetails("Ruru");
            return await Mediator.Send(request);
        }

        // PUT api/<CountyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountyController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {

            await Mediator.Send(new DeleteCountryCommand
            {
                Id = id,
                UserModel = await this.GetUserDetails("Ruru")
            });
            return NoContent();
        }
    }
}