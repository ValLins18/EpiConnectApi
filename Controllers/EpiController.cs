using AutoMapper;
using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpiConnectAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EpiController : ControllerBase {

        private readonly IEpiRepository _epiRepository;
        private readonly IMapper _mapper;

        public EpiController(IEpiRepository epiRepository, IMapper mapper) {
            _epiRepository = epiRepository;
            _mapper = mapper;
        }

        // GET: api/<EpiController>
        [HttpGet]
        public async Task<IActionResult> GetAllEpis() {
            return Ok(await _epiRepository.GetEpis());
        }

        // GET api/<EpiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpi(int id) {
            return Ok(await _epiRepository.GetEpiById(id));
        }

        // POST api/<EpiController>
        [HttpPost]
        public async Task<IActionResult> CreateEpi([FromBody] EpiRequestView epiRequest) {
            Epi epi = _mapper.Map<Epi>(epiRequest);
            return Created("", await _epiRepository.CreateEpi(epi));
        }

        // PUT api/<EpiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<EpiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
