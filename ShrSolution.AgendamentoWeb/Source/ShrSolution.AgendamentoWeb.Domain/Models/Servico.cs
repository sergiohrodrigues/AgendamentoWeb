using System.Text.Json.Serialization;

namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int EmpresaId { get; set; }
        [JsonIgnore]
        public Empresa Empresa{ get; set; }
    }
}
