using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class ServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public ICollection<SchedulingModel> Schedulings { get; set; }
        public int EnterpriseId { get; set; }
        [JsonIgnore]
        public EnterpriseModel Enterprise{ get; set; }
        public int ProfessionalId { get; set; }
        [JsonIgnore]
        public ProfessionalModel Professional{ get; set; }
    }
}
