using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class ProfessionalModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? Email { get; set; }

        public string Telefone { get; set; }

        public bool Ativo { get; set; } = true;

        public int EnterpriseId { get; set; }

        [JsonIgnore]
        public EnterpriseModel Enterprise { get; set; }

        [JsonIgnore]
        public ICollection<ServiceModel> Services { get; set; } = new List<ServiceModel>();

        [JsonIgnore]
        public ICollection<AgendaDisponivel> AgendasBase { get; set; } = new List<AgendaDisponivel>();


        // Lista de serviços que o profissional pode realizar
        //public List<ProfissionalServico> ProfissionalServicos { get; set; } = new();

        // Agenda ou agendamentos feitos com esse profissional
        //public List<Agendamento> Agendamentos { get; set; } = new();

        // Horários fixos de atendimento (ex: seg a sex, 08h - 18h)
        //public List<HorarioAtendimento> HorariosAtendimento { get; set; } = new();
    }

}
