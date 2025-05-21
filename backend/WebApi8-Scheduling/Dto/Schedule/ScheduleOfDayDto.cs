using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Dto.Schedule;

public class ScheduleOfDayDto
{
    public DiaEHorariosModel Day { get; set; }
    public List<string> TimeSlots { get; set; }
}
