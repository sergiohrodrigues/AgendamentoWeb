using System.Text.Json.Serialization;
using ShrSolution.AgendamentoWeb.Domain.Core;

namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class Servico : Entity<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public virtual Empresa Empresa{ get; set; }
        public int EmpresaId { get; set; }
    }
}
