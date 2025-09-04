namespace ShrSolution.AgendamentoWeb.Application.Dto.Professional
{
    public class ProfessionalCreateDto
    {
        public string Nome { get; set; }

        public string? Email { get; set; }

        public string Telefone { get; set; }
        public int EnterpriseId { get; set; }
    }
}
