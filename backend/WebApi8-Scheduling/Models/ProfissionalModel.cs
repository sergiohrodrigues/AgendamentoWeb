using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class ProfissionalModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? Email { get; set; }

        public string Telefone { get; set; }

        public bool Ativo { get; set; } = true;

        public int EmpresaId { get; set; }

        [JsonIgnore]
        public EmpresaModel Empresa { get; set; }

        // [JsonIgnore]
        // public ICollection<ServicoModel> Services { get; set; } = new List<ServicoModel>();
    }

}
