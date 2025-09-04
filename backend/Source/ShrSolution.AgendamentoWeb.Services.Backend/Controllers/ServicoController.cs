// using Microsoft.AspNetCore.Mvc;
// using WebApi8_Scheduling.Domain.Models;
// using WebApi8_Scheduling.Domain.Services.Interfaces;
// using WebApi8_Scheduling.Dto.Service;
//
// namespace WebApi8_Scheduling.Services.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ServicoController : Controller
//     {
//         private readonly IServicoInterface _servicoInterface;
//
//         public ServicoController(IServicoInterface servicoInterface)
//         {
//             _servicoInterface = servicoInterface;
//         }
//         
//         [HttpPost]
//         public async Task<ActionResult<ResponseModel<Servico>>> CreateService(CriarServicoDto pService)
//         {
//             var services = await _servicoInterface.CreateService(pService);
//             return Ok(services);
//         }
//     }
// }
