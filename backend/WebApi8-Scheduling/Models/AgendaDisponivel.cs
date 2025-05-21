using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class AgendaDisponivel
    {
        public int Id { get; set; }

        public int DiaDaSemana { get; set; }

        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }


        public int ProfissionalId { get; set; }
        [JsonIgnore]
        public ProfessionalModel Profissional { get; set; } = null!;
        public int TurnoTrabalhoId { get; set; }
        [JsonIgnore]
        public WorkShiftModel TurnoTrabalho { get; set; }
    }

}
