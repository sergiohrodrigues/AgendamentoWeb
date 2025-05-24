using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }

        public int EmpresaId { get; set; }

        [JsonIgnore]
        public EmpresaModel Empresa { get; set; }

        public int ClienteId { get; set; }

        [JsonIgnore]
        public ClienteModel Cliente { get; set; }

        public int ProfissionalId { get; set; }

        [JsonIgnore]
        public ProfissionalModel Profissional { get; set; }

        public int ServicoId { get; set; }

        [JsonIgnore]
        public ServicoModel Servico { get; set; }
    }
}