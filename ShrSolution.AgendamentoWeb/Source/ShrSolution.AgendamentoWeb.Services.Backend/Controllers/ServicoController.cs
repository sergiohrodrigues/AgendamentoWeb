using Microsoft.AspNetCore.Mvc;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.Response;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Servico;

namespace ShrSolution.AgendamentoWeb.Services.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : Controller
    {
        private readonly IServicoApplicationService _servicoApplicationService;

        public ServicoController(IServicoApplicationService servicoApplicationService)
        {
            _servicoApplicationService = servicoApplicationService;
        }

        [HttpGet("{servicoId}")]
        public async Task<ActionResult<ResponseModel<ServicoViewModel>>> ObterServicoPorId(int servicoId)
        {
            try
            {
                var xProfissinoal = await _servicoApplicationService.ObterServicoPorId(servicoId);
                return Ok(xProfissinoal);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AdicionarServicoViewModel>>> Adicionar(AdicionarServicoViewModel pAdicionarServicoViewModel)
        {
            try
            {
                var xRetorno = await _servicoApplicationService.Adicionar(pAdicionarServicoViewModel);
                return Ok(xRetorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
