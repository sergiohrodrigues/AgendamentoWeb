using Microsoft.AspNetCore.Mvc;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.Response;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Agendamento;

namespace ShrSolution.AgendamentoWeb.Services.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoApplicationService _agendamentoApplicationService;

        public AgendamentoController(IAgendamentoApplicationService agendamentoApplicationService)
        {
            _agendamentoApplicationService = agendamentoApplicationService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AdicionarAgendamentoViewModel>>> AdicionarAgendamento(AdicionarAgendamentoViewModel pAdicionarAgendamentoViewModel)
        {
            try
            {
                var xAgendamento = await _agendamentoApplicationService.Adicionar(pAdicionarAgendamentoViewModel);
                return Ok(xAgendamento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{pAgendamentoId}")]
        public async Task<ActionResult<ResponseModel<AgendamentoViewModel>>> ObterAgendamentoPorId(int pAgendamentoId)
        {
            try
            {
                var xAgendamento = await _agendamentoApplicationService.ObterAgendamentoPorId(pAgendamentoId);
                return Ok(xAgendamento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<ResponseModel<AgendamentoViewModel>>> ObterTodosAgendamentos()
        {
            try
            {
                var xAgendamentos = _agendamentoApplicationService.ObterTodosAgendamentos();
                return Ok(xAgendamentos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
