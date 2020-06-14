using Helpdesk.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Helpdesk.WebApi.References.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantMappingController : ApiController
    {
        // GET: api/<ConsultantMappingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConsultantMappingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConsultantMappingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConsultantMappingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultantMappingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}