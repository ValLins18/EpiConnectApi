using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpiConnectAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase {

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }
    }
}
