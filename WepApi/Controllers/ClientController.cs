using Apllication.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientInterface _repo;
        public ClientController(IClientInterface repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Return Clients's information
        /// </summary>

        [HttpGet("clients")]
        public async Task<IActionResult> AllClient()
        {
            var allClient = await _repo.GetAllClientsAsync();

            return allClient.Any() ? Ok(allClient) : NotFound();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
