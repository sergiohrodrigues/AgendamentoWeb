using ShrSolution.AgendamentoWeb.Domain.Core;

namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class Agendamento  : Entity<int>
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public virtual Profissional Profissional { get; set; }
        public int ProfissionalId { get; set; }
        public virtual Servico Servico { get; set; }
        public int ServicoId { get; set; }
    }
}