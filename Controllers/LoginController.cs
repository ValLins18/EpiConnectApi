using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpiConnectAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {

        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }



        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserRequestView userRequest) {
            User user = await _userRepository.GetUserByEmail(userRequest.Email);
            if (user == null) {
                return NotFound();
            }
            if (!userRequest.Password.Equals(user.Password)) {
                return BadRequest("Password incorrect");
            }
            return Ok();
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
