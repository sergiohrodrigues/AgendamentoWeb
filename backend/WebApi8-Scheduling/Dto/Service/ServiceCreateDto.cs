using System.Text.Json.Serialization;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Dto.Service
{
    public class ServiceCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int EnterpriseId { get; set; }
        public int ProfessionalId { get; set; }
    }
}
