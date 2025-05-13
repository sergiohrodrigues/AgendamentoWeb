using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models;

public class UserModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    [JsonIgnore]
    public EnterpriseModel? Enterprise { get; set; }
    public int? EnterpriseId { get; set; }
}