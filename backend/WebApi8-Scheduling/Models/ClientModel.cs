using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public ICollection<SchedulingModel> Schedulings { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public UserModel User { get; set; }

    }
}
