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
        
        [HttpPut("{professionalId}")]
        public async Task<ActionResult<ResponseModel<AgendaBaseModel>>> EditAgendaBase(int professionalId, AgendaBaseEditDto agendaBaseEditDto)
        {
            var agendaBase = await _agendaBaseInterface.EditAgendaBase(professionalId, agendaBaseEditDto);
            return Ok(agendaBase);
        }
    }
}
