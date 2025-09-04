using System.ComponentModel.DataAnnotations;

namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(18)]
        public string Cnpj { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [MaxLength(200)]
        public string Endereco { get; set; }

        public bool Ativo { get; set; } = true;

        // [JsonIgnore]
        // public ICollection<Profissional> Professionals { get; set; } = new List<Profissional>();
        // [JsonIgnore]
        // public ICollection<Servico> Services { get; set; } = new List<Servico>();

    }
}
