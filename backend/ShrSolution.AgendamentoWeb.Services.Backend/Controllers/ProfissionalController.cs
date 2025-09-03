// using Microsoft.AspNetCore.Mvc;
// using ShrSolution.AgendamentoWeb.Domain.Models;
// using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;
//
// namespace ShrSolution.AgendamentoWeb.Services.Backend.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ProfissionalController : ControllerBase
//     {
//         private readonly IProfessionalService _professionalInterface;
//
//         public ProfissionalController(IProfessionalService schedulingInterface)
//         {
//             _professionalInterface = schedulingInterface;
//         }
//
//         [HttpGet("{ProfissionalId}")]
//         public async Task<ActionResult<ResponseModel<List<Profissional>>>> ObterProfissionalPorId(int ProfissionalId)
//         {
//             var newEnterprise = await _professionalInterface.ObterProfissionalPorId(ProfissionalId);
//             return Ok(newEnterprise);
//         }
//     }
// }
