using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.Scheduling;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.Scheduling;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoInterface _agendamentoInterface;

        public AgendamentoController(IAgendamentoInterface agendamentoInterface)
        {
            _agendamentoInterface = agendamentoInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AgendamentoModel>>> CreateSheduling(SchedulingCreateDto schedulingCreateDto)
        {
            var scheduling = await _agendamentoInterface.CreateSheduling(schedulingCreateDto);
            return Ok(scheduling);
        }
        
        [HttpDelete]
        public async Task<ActionResult<ResponseModel<AgendamentoModel>>> DeleteScheduling(int idScheduling)
        {
            var scheduling = await _agendamentoInterface.DeleteScheduling(idScheduling);
            return Ok(scheduling);
        }
        
        [HttpGet]
        public async Task<ActionResult<ResponseModel<AgendamentoModel>>> GetAllSchedulings(int EnterpriseId)
        {
            var schedulings = await _agendamentoInterface.GetAllSchedulings(EnterpriseId);
            return Ok(schedulings);
        }
    }
}
