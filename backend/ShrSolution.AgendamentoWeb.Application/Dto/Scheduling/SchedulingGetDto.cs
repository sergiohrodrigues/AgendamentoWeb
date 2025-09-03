namespace ShrSolution.AgendamentoWeb.Application.Dto.Scheduling
{
    public class SchedulingGetDto
    {
        public DateTime DateHour { get; set; }
        public string Observation { get; set; }
        public int ServiceId { get; set; }
        public int EnterpriseId { get; set; }
        public int ClientId { get; set; }
        public int ProfessionalId { get; set; }
    }
}
