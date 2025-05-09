using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class AgendaBaseModel
    {
        public int Id { get; set; }

        public int DayWeek { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int ProfessionalId { get; set; }
        [JsonIgnore]
        public ProfessionalModel Professional { get; set; } = null!;
        public int WorkShiftId { get; set; }
        [JsonIgnore]
        public WorkShiftModel WorkShift { get; set; }
    }

}
