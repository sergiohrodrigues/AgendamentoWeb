using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.User;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.User;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterpriseController : ControllerBase
    {
        private readonly IEnterpriseInterface _enterpriseInterface;

        public EnterpriseController(IEnterpriseInterface enterpriseInterface)
        {
            _enterpriseInterface = enterpriseInterface;
        }

        [HttpPost("CreateEnterprise")]
        public async Task<ActionResult<ResponseModel<EnterpriseModel>>> CreateEnterprise(EnterpriseCreateDto enterprise)
        {
            var newEnterprise = await _enterpriseInterface.CreateEnterprise(enterprise);
            return Ok(newEnterprise);
        }
        
        [HttpPost("LoginEnterprise")]
        public async Task<ActionResult<ResponseModel<EnterpriseModel>>> LoginEnterprise(EnterpriseLoginDto enterpriseLoginDto)
        {
            var enterpriseLogin = await _enterpriseInterface.LoginEnterprise(enterpriseLoginDto);
            return Ok(enterpriseLogin);
        }


    }
}
