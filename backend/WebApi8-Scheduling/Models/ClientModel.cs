using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        //[JsonIgnore]
        //public ICollection<SchedulingModel> Schedulings { get; set; }

        public int EnterpriseId { get; set; }
        [JsonIgnore]
        public EnterpriseModel Enterprise { get; set; }

    }
}
