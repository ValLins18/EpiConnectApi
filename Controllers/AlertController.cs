using AutoMapper;
using EpiConnectAPI.Core.Enums;
using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EpiConnectAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase {
        private readonly IAlertRepository _alertRepository;
        private readonly IMapper _mapper;

        public AlertController(IAlertRepository alertRepository, IMapper mapper) {
            _alertRepository = alertRepository;
            _mapper = mapper;
        }


        // GET: api/<AlertController>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlertController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<AlertController>
        [HttpPost("/abrirAlerta")]
        public async Task<IActionResult> AbrirAlerta([FromBody] AlertRequestView alertRequest) {
            Alert alert = _mapper.Map<Alert>(alertRequest);
            alert.AlertDate = DateTime.Now;
            await _alertRepository.OpenAlert(alert);
            return Created("", alert);
        }


        // PUT api/<AlertController>/5+
        [HttpPut("/fecharAlerta/{EpiId}")]
        public async Task<IActionResult> FecharAlerta(int EpiId) {
            Alert OpenedAlert = await _alertRepository.GetLastAlertByEpiId(EpiId);
            OpenedAlert.UnprotectedTime = DateTime.Now - OpenedAlert.AlertDate;
            OpenedAlert.IsOpen = false;

            //TODO Regra que define Nivel de periculosidade(dangerousLevel)

            OpenedAlert.DangerousLevel = DangerousLevel.LOW;

            await _alertRepository.CloseAlert(EpiId, OpenedAlert);
            return Ok(new {
                OpenedAlert.UnprotectedTime,
                OpenedAlert.IsOpen,
                DangerousLevel = OpenedAlert.DangerousLevel.ToString()
            });
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
