namespace ShrSolution.AgendamentoWeb.Domain.Models;

public class ProfissionalServico
{
    public int ProfissionalId { get; set; }
    public Profissional Profissional { get; set; }
    public int ServicoId { get; set; }
    public Servico Servico { get; set; }
}