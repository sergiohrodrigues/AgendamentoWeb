using Microsoft.AspNetCore.Mvc;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.Response;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;

namespace ShrSolution.AgendamentoWeb.Services.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalApplicationService _profissionalApplicationService;

        public ProfissionalController(IProfissionalApplicationService profissionalApplicationService)
        {
            _profissionalApplicationService = profissionalApplicationService;
        }

        [HttpGet("{profissionalId}")]
        public async Task<ActionResult<ResponseModel<ProfissionalViewModel>>> ObterProfissionalPorId(int profissionalId)
        {
            try
            {
                var xProfissinoal = await _profissionalApplicationService.ObterProfissionalPorId(profissionalId);
                return Ok(xProfissinoal);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseModel<AdicionarProfissionalViewModel>>> Adicionar(AdicionarProfissionalViewModel pAdicionarProfissionalViewModel)
        {
            try
            {
                var xRetorno = await _profissionalApplicationService.Adicionar(pAdicionarProfissionalViewModel);
                return Ok(xRetorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
