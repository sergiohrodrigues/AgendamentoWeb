using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.AgendaBase;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.AgendaBase;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaBaseController : ControllerBase
    {
        private readonly IAgendaDisponivelService _agendaDisponivelInterface;

        public AgendaBaseController(IAgendaDisponivelService agendaDisponivelService)
        {
            _agendaDisponivelInterface = agendaDisponivelService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AgendaDisponivel>>> CreateAgendaBase(AgendaBaseCreateDto pAgendaBase)
        {
            var agendaBase = await _agendaDisponivelInterface.CreateAgendaBase(pAgendaBase);
            return Ok(agendaBase);
        }
        
        [HttpPost("agenda-default")]
        public async Task<ActionResult<ResponseModel<AgendaDisponivel>>> AddDefaultAgenda(int pProfessionalId)
        {
            var agendaBase = await _agendaDisponivelInterface.AddDefaultSchedules(pProfessionalId);
            return Ok(agendaBase);
        }
        
        [HttpPut("{professionalId}")]
        public async Task<ActionResult<ResponseModel<AgendaDisponivel>>> EditAgendaBase(int professionalId, AgendaBaseEditDto agendaBaseEditDto)
        {
            var agendaBase = await _agendaDisponivelInterface.EditAgendaBase(professionalId, agendaBaseEditDto);
            return Ok(agendaBase);
        }
    }
}
