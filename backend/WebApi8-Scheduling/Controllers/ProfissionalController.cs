using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.Professional;
using WebApi8_Scheduling.Dto.Service;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.Professional;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfessionalService _professionalInterface;

        public ProfissionalController(IProfessionalService schedulingInterface)
        {
            _professionalInterface = schedulingInterface;
        }

        [HttpGet("{enterpriseId}")]
        public async Task<ActionResult<ResponseModel<List<ProfissionalModel>>>> GetAllProfessionals(int enterpriseId)
        {
            var newEnterprise = await _professionalInterface.GetAllProfessional(enterpriseId);
            return Ok(newEnterprise);
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseModel<ProfissionalModel>>> CreateProfessional(ProfessionalCreateDto pProfessional)
        {
            var newEnterprise = await _professionalInterface.CreateProfessional(pProfessional);
            return Ok(newEnterprise);
        }
        
        [HttpGet("{professionalId}/servicos")]
        public async Task<ActionResult<ResponseModel<List<ServicosDto>>>> BuscarServicosProfissional(int professionalId)
        {
            var servicos = await _professionalInterface.BuscarServicosProfissional(professionalId);
            return Ok(servicos);
        }
        
        
    }
}
