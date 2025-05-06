namespace WebApi8_Scheduling.Dto.AgendaBase
{
    public class AgendaBaseCreateDto
    {
        public int ProfessionalId { get; set; }

        public int DayWeek { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
