using Microsoft.AspNetCore.Mvc;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.Response;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;

namespace ShrSolution.AgendamentoWeb.Services.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaApplicationService _empresaApplicationService;

        public EmpresaController(IEmpresaApplicationService empresaApplicationService)
        {
            _empresaApplicationService = empresaApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<EmpresaViewModel>>> ObterEmpresaPorId(int pEmpresaId)
        {
            try
            {
                var newEnterprise = await _empresaApplicationService.ObterEmpresaPorId(pEmpresaId);
                return Ok(newEnterprise);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<AdicionarEmpresaViewModel>>> Adicionar(AdicionarEmpresaViewModel pAdicionarEmpresaViewModel)
        {
            try
            {
                var xRetorno = await _empresaApplicationService.Adicionar(pAdicionarEmpresaViewModel);
                return Ok(xRetorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
