namespace ShrSolution.AgendamentoWeb.Domain.Models;

public class AgendaIndisponivel
{
    public int Id { get; set; }
    public int ProfissionalId { get; set; }
    public DateTime Data { get; set; }
    public string Motivo { get; set; }
}