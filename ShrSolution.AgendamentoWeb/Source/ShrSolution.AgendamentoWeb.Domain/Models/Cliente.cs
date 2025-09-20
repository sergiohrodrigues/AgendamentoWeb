using ShrSolution.AgendamentoWeb.Domain.Core;

namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class Cliente : Entity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
