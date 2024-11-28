using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.Scheduling;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.Scheduling;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingInterface _schedulingInterface;

        public SchedulingController(ISchedulingInterface schedulingInterface)
        {
            _schedulingInterface = schedulingInterface;
        }

        [HttpPost("CreateSheduling")]
        public async Task<ActionResult<ResponseModel<SchedulingModel>>> CreateSheduling(SchedulingCreateDto schedulingCreateDto)
        {
            var scheduling = await _schedulingInterface.CreateSheduling(schedulingCreateDto);
            return Ok(scheduling);
        }
        
        [HttpDelete("DeleteScheduling")]
        public async Task<ActionResult<ResponseModel<SchedulingModel>>> DeleteScheduling(int idScheduling)
        {
            var scheduling = await _schedulingInterface.DeleteScheduling(idScheduling);
            return Ok(scheduling);
        }
    }
}
