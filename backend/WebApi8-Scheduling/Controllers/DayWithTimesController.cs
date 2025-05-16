using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Services.Time;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayWithTimesController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public DayWithTimesController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        public IActionResult GetTimesToYear()
        {
            var resultado = _timeService.GenerateSchedulesOfTheYear();
            return Ok(resultado);
        }

        //// ❌ DELETE: Remove um dia inteiro
        //[HttpDelete("dia/{date}")]
        //public IActionResult RemoveDay(string date)
        //{
        //    if (!DateTime.TryParse(date, out var day))
        //        return BadRequest("Data inválida");

        //    _timeService.RemoveDay(ref _timeService, day);
        //    return NoContent();
        //}

        //// ❌ DELETE: Remove um horário específico de um dia
        //[HttpDelete("dia/{data}/hora/{hora}")]
        //public IActionResult RemoveHourFromDay(string data, string hora)
        //{
        //    if (!DateTime.TryParse(data, out var day) || !TimeSpan.TryParse(hora, out var time))
        //        return BadRequest("Data ou hora inválida");

        //    _scheduleService.RemoveTimeFromDay(ref _schedules, day, time);
        //    return NoContent();
        //}
    }
}
