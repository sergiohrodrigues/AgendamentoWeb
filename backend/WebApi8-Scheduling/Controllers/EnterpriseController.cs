using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.Empresa;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEmpresaInterface _empresaInterface;

        public EnterpriseController(IEmpresaInterface empresaInterface)
        {
            _empresaInterface = empresaInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<EmpresaModel>>> CreateEnterprise(EnterpriseCreateDto enterprise)
        {
            var newEnterprise = await _empresaInterface.CreateEnterprise(enterprise);
            return Ok(newEnterprise);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseModel<EmpresaModel>>> LoginEnterprise(EnterpriseLoginDto enterpriseLoginDto)
        {
            var enterpriseLogin = await _empresaInterface.LoginEnterprise(enterpriseLoginDto);
            return Ok(enterpriseLogin);
        }


    }
}
