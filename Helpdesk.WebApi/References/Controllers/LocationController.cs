using Helpdesk.Application.BusinessLogic.LocationBL.Command.Add;
using Helpdesk.Application.BusinessLogic.LocationBL.Query.GetAll;
using Helpdesk.Application.BusinessLogic.LocationBL.Query.GetById;
using Helpdesk.Domain.Entities;
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
    public class LocationController : ApiController
    {
        // GET: api/<LocationController>
        [HttpGet]
        public async Task<ActionResult<LocationListModel>> Get()
        {
            return await Mediator.Send(new GetAllLocationQuery());
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public async Task<LocationModel> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetLocationByIdQuery { Id = id });
            return vm;
        }

        // POST api/<LocationController>
        [HttpPost]
        public async Task<Unit> Post([FromBody] CreateLocationCommand request)
        {
            request.UserModel = await GetUserDetails("Ruru");
            return await Mediator.Send(request);
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}