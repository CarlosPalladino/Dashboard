using Apllication.Interfaces.Services;
using Apllication.Records;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Return Client's information
        /// </summary>        
        [HttpGet("{name}")]
        public async Task<IActionResult> GetclientByName(string name)
        {
            var client = await _repo.GetClientInformation(name);
            return Ok(client);
        }
        /// <summary>
        /// Endpoint to manage new client 
        /// </summary>
        /// <param name="record"></param>
        [HttpPost]
        public async Task<IActionResult> NewClient([FromBody] NewClientRecord newclient)
        {
            var newClient = await _repo.CreateClientAsync(newclient);

            return Ok("the client was created successfully");
        }

        // PUT api/<ClientController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] )
        //{
        //    return 
        //}

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
