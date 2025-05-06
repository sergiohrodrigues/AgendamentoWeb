using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.AgendaBase;
using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.AgendaBase;
using WebApi8_Scheduling.Services.Client;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaBaseController : ControllerBase
    {
        private readonly IAgendaBaseService _agendaBaseInterface;

        public AgendaBaseController(IAgendaBaseService agendaBaseService)
        {
            _agendaBaseInterface = agendaBaseService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AgendaBaseModel>>> CreateAgendaBase(AgendaBaseCreateDto pAgendaBase)
        {
            var agendaBase = await _agendaBaseInterface.CreateAgendaBase(pAgendaBase);
            return Ok(agendaBase);
        }
        
        [HttpPost("agenda-default")]
        public async Task<ActionResult<ResponseModel<AgendaBaseModel>>> AddDefaultAgenda(int pProfessionalId)
        {
            var agendaBase = await _agendaBaseInterface.AddDefaultSchedules(pProfessionalId);
            return Ok(agendaBase);
        }
    }
}
