using AutoMapper;
using EpiConnectAPI.Core;
using EpiConnectAPI.Core.Enums;
using EpiConnectAPI.Core.Model;
using EpiConnectAPI.Core.ViewModel;
using EpiConnectAPI.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("/workshiftalerts")]
        public async Task<IActionResult> GetAlertsByDepartment() {
            return Ok(await _alertRepository.GetAlertsCountByWorkshift());
        }

        // POST api/<AlertController>
        [AllowAnonymous]
        [HttpPost("/abrirAlerta")]
        public async Task<IActionResult> AbrirAlerta([FromBody] AlertRequestView alertRequest) {
            Alert OpenedAlert = await _alertRepository.GetLastAlertByEpiId(alertRequest.EpiId);
            //Se já tiver alerta aberto ele só manda uma mensagem de sucesso sem conteudo e não abre um novo alerta.
            if (OpenedAlert != null) {
                return NoContent();
            }
            Alert alertDto = _mapper.Map<Alert>(alertRequest);
            alertDto.AlertDate = DateTime.Now;
            await _alertRepository.OpenAlert(alertDto);
            return Created("", alertDto);
        }

        // PUT api/<AlertController>/5+
        [AllowAnonymous]
        [HttpPut("/fecharAlerta/{EpiId}")]
        public async Task<IActionResult> FecharAlerta(int EpiId) {
            Alert OpenedAlert = await _alertRepository.GetLastAlertByEpiId(EpiId);
            if (OpenedAlert != null) {
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
            return NoContent();
        }
    }
}
