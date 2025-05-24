using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int EmpresaId { get; set; }
        [JsonIgnore]
        public EmpresaModel Empresa{ get; set; }
    }
}
