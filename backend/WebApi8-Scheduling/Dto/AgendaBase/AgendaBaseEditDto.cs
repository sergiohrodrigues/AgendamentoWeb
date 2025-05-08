namespace WebApi8_Scheduling.Dto.AgendaBase
{
    public class AgendaBaseEditDto
    {
        public int DayWeek { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
