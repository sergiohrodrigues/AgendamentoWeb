using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class EnterpriseModel
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

        [JsonIgnore]
        public ICollection<ProfessionalModel> Professionals { get; set; } = new List<ProfessionalModel>();
        [JsonIgnore]
        public ICollection<ServiceModel> Services { get; set; } = new List<ServiceModel>();
        [JsonIgnore]
        public ICollection<ClientModel> Clients { get; set; } = new List<ClientModel>();

    }
}
