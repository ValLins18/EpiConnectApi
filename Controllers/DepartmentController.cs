using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpiConnectAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase {

        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository) {
            _departmentRepository = departmentRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetDepartments() {
            return Ok(await _departmentRepository.GetDepartmentsAsync());
        }
        [AllowAnonymous]
        [HttpGet("Alerts")]
        public async Task<IActionResult> GetAlertsByDepartment() {
            return Ok(await _departmentRepository.GetCountAlertsByDepartment());
        }
    }
}
