using AutoMapper;
using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using EpiConnectAPI.Services.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace EpiConnectAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginController(IEmployeeRepository employeeRepository, ITokenService tokenService, UserManager<IdentityUser> userManager, IMapper mapper) {
            _employeeRepository = employeeRepository;
            _tokenService = tokenService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken(UserRequestView userRequest) {
            if (userRequest == null) {
                return BadRequest("Login Cannot be null");
            }
            var user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user == null) {
                return BadRequest("User does not exists");
            }
            var passwordCheck = await _userManager.CheckPasswordAsync(user, userRequest.Password);
            if (!passwordCheck) {
                return BadRequest("Wrong Password");
            }
            var claims = await _userManager.GetClaimsAsync(user);
            var token = _tokenService.GetToken(user, claims);
            return Ok(token);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] EmployeeRequestView employeeRequest) {
            try {
                var user = new IdentityUser {
                    Email = employeeRequest.Email,
                    UserName = employeeRequest.Email,
                    PhoneNumber = employeeRequest.Phone.DDD + employeeRequest.Phone.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, employeeRequest.User.Password);
                if (!result.Succeeded) {
                    return BadRequest(result.Errors);
                }
                var employee = _mapper.Map<Employee>(employeeRequest);
                employee = await _employeeRepository.CreateEmployee(employee);

                var claims = new List<Claim> {
                    new Claim(nameof(employee.PersonId), employee.PersonId.ToString()),
                    new Claim(nameof(employee.Name), employee.Name)
                };

                var claimResult = await _userManager.AddClaimsAsync(user, claims);
                if(!claimResult.Succeeded) {
                    await _employeeRepository.DeleteEmployee(employee.PersonId);
                    return BadRequest(claimResult.Errors);
                }
                return Created("", new { user.Id, user.Email, employee.PersonId });
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
