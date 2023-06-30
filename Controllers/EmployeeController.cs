using AutoMapper;
using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpiConnectAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper) {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> GetEmployees() {
            return Ok(await _employeeRepository.GetEmployees());
        }

        [HttpGet("Monitoring")]
        public async Task<IActionResult> GetEmployeesForMonitoring() {
            return Ok(await _employeeRepository.GetEmployeesForMonitoring());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id) {
            var employee = await _employeeRepository.GetEmployeeById(id);
            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequestView employeeRequest) {
            var employee = _mapper.Map<Employee>(employeeRequest);
            await _employeeRepository.CreateEmployee(employee);
            return Created("", employeeRequest);
        }
    }
}
