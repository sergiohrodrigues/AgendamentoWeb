using ShrSolution.AgendamentoWeb.Domain.Core;

namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class Empresa : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Cnpj { get; set; }
        public string? Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public bool Ativo { get; set; } = true;

        // [JsonIgnore]
        // public ICollection<Profissional> Professionals { get; set; } = new List<Profissional>();
        // [JsonIgnore]
        // public ICollection<Servico> Services { get; set; } = new List<Servico>();
    }
}
