using System.Text.Json.Serialization;
using ShrSolution.AgendamentoWeb.Domain.Core;

namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class Profissional : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
        public virtual Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }

        // [JsonIgnore]
        // public ICollection<ServicoModel> Services { get; set; } = new List<ServicoModel>();
    }

}
