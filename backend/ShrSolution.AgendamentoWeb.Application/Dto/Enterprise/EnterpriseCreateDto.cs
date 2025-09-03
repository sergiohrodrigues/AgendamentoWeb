using System.ComponentModel.DataAnnotations;

namespace ShrSolution.AgendamentoWeb.Application.Dto.Enterprise
{
    public class EnterpriseCreateDto
    {
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
    }
}
