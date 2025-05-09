using System.Text.Json.Serialization;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Dto.Scheduling
{
    public class SchedulingCreateDto
    {
        public DateTime DateHour { get; set; }
        public string Observation { get; set; }
        public int ServiceId { get; set; }
        public int EnterpriseId { get; set; }
        public int ClientId { get; set; }
        public int ProfessionalId { get; set; }
    }
}
