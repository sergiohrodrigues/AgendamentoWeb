// using Microsoft.AspNetCore.Mvc;
// using ShrSolution.AgendamentoWeb.Application.Dto.Scheduling;
// using ShrSolution.AgendamentoWeb.Application.Response;
// using ShrSolution.AgendamentoWeb.Domain.Models;
// using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;
//
// namespace ShrSolution.AgendamentoWeb.Services.Backend.Controllers
// {
//     [Microsoft.AspNetCore.Components.Route("api/[controller]")]
//     [ApiController]
//     public class AgendamentoController : ControllerBase
//     {
//         private readonly IAgendamentoInterface _agendamentoInterface;
//
//         public AgendamentoController(IAgendamentoInterface agendamentoInterface)
//         {
//             _agendamentoInterface = agendamentoInterface;
//         }
//
//         [HttpPost]
//         public async Task<ActionResult<ResponseModel<Agendamento>>> CreateSheduling(SchedulingCreateDto schedulingCreateDto)
//         {
//             var scheduling = await _agendamentoInterface.CreateSheduling(schedulingCreateDto);
//             return Ok(scheduling);
//         }
//         
//         [HttpDelete]
//         public async Task<ActionResult<ResponseModel<Agendamento>>> DeleteScheduling(int idScheduling)
//         {
//             var scheduling = await _agendamentoInterface.DeleteScheduling(idScheduling);
//             return Ok(scheduling);
//         }
//         
//         [HttpGet]
//         public async Task<ActionResult<ResponseModel<Agendamento>>> GetAllSchedulings(int EnterpriseId)
//         {
//             var schedulings = await _agendamentoInterface.GetAllSchedulings(EnterpriseId);
//             return Ok(schedulings);
//         }
//     }
// }
