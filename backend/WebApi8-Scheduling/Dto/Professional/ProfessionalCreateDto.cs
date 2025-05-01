namespace WebApi8_Scheduling.Dto.Professional
{
    public class ProfessionalCreateDto
    {
        public string Nome { get; set; }

        public string? Email { get; set; }

        public string Telefone { get; set; }
        public int EnterpriseId { get; set; }
    }
}
