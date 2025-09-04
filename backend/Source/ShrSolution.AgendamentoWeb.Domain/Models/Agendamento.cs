using System.Text.Json.Serialization;

namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }

        public int EmpresaId { get; set; }

        [JsonIgnore]
        public Empresa Empresa { get; set; }

        public int ClienteId { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }

        public int ProfissionalId { get; set; }

        [JsonIgnore]
        public Profissional Profissional { get; set; }

        public int ServicoId { get; set; }

        [JsonIgnore]
        public Servico Servico { get; set; }
    }
}