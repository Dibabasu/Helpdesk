using Helpdesk.Application.BusinessLogic.LocationTypeBL.Command.Add;
using Helpdesk.Application.BusinessLogic.LocationTypeBL.Query.GetAll;
using Helpdesk.Application.BusinessLogic.LocationTypeBL.Query.GetById;
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
    public class LocationTypeController : ApiController
    {
        // GET: api/<LocationTypeController>
        [HttpGet]
        public async Task<LocationTypeListModel> Get()
        {
            return await Mediator.Send(new GetAllLocationTypeQuery());
        }

        // GET api/<LocationTypeController>/5
        [HttpGet("{id}")]
        public async Task<LocationTypeModel> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetLocationTypeByIdQuery { Id = id });
            return vm;
        }

        // POST api/<LocationTypeController>
        [HttpPost]
        public async Task Post([FromBody] CreateLocationTypeCommand request)
        {
            request.UserModel = await GetUserDetails("Ruru");
            await Mediator.Send(request);
        }

        // PUT api/<LocationTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}