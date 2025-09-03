using Microsoft.AspNetCore.Mvc;
using ShrSolution.AgendamentoWeb.Application.Dto.Enterprise;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.ViewModels;
using ShrSolution.AgendamentoWeb.Domain.Models;

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
            var newEnterprise = await _empresaApplicationService.ObterEmpresaPorId(pEmpresaId);
            return Ok(newEnterprise);
        }
        //
        // [HttpPost("login")]
        // public async Task<ActionResult<ResponseModel<Empresa>>> LoginEnterprise(EnterpriseLoginDto enterpriseLoginDto)
        // {
        //     var enterpriseLogin = await _empresaInterface.LoginEnterprise(enterpriseLoginDto);
        //     return Ok(enterpriseLogin);
        // }


    }
}
