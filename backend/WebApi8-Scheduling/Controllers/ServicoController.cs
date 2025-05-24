using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.Service;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.Servico;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : Controller
    {
        private readonly IServicoInterface _servicoInterface;

        public ServicoController(IServicoInterface servicoInterface)
        {
            _servicoInterface = servicoInterface;
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseModel<ServicoModel>>> CreateService(CriarServicoDto pService)
        {
            var services = await _servicoInterface.CreateService(pService);
            return Ok(services);
        }
    }
}
