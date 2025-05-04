namespace WebApi8_Scheduling.Dto.Scheduling
{
    public class SchedulingCreateDto
    {
        public DateTime DateHour { get; set; }
        public string Observation { get; set; }
        public int ServiceId { get; set; }
    }
}
