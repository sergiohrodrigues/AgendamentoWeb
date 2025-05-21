using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.Professional;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.Professional;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IProfessionalService _professionalInterface;

        public ProfessionalController(IProfessionalService schedulingInterface)
        {
            _professionalInterface = schedulingInterface;
        }

        [HttpGet("{enterpriseId}")]
        public async Task<ActionResult<ResponseModel<List<ProfessionalModel>>>> GetAllProfessionals(int enterpriseId)
        {
            var newEnterprise = await _professionalInterface.GetAllProfessional(enterpriseId);
            return Ok(newEnterprise);
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseModel<ProfessionalModel>>> CreateProfessional(ProfessionalCreateDto pProfessional)
        {
            var newEnterprise = await _professionalInterface.CreateProfessional(pProfessional);
            return Ok(newEnterprise);
        }
        
        [HttpGet("schedules/{dayWeekId}/{professionalId}")]
        public async Task<ActionResult<ResponseModel<string>>> GetSchedulesProfessional(int dayWeekId, int professionalId)
        {
            var schedules = await _professionalInterface.GetSchedulesProfessional(dayWeekId, professionalId);
            return Ok(schedules);
        }
        
        [HttpGet("{professionalId}/agenda-disponivel")]
        public async Task<ActionResult<ResponseModel<List<DateTime>>>> BuscarHorariosDisponiveis(int profissionalId, DateTime dataInicial, DateTime dataFinal)
        {
            var horarios = await _professionalInterface.BuscarHorariosDisponiveis(profissionalId, dataInicial, dataFinal);
            return Ok(horarios);
        }
    }
}
