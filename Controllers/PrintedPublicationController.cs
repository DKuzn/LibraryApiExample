using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintedPublicationController : ControllerBase
    {
        // GET: api/<PrintedPublicationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PrintedPublicationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrintedPublicationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrintedPublicationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrintedPublicationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
