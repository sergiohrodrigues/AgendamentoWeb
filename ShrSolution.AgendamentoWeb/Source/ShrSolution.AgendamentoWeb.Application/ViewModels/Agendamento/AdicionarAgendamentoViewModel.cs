namespace ShrSolution.AgendamentoWeb.Application.ViewModels.Agendamento;

public class AdicionarAgendamentoViewModel
{
    public DateTime Data { get; set; }
    public string Observacao { get; set; }
    public int EmpresaId { get; set; }
    public int ClienteId { get; set; }
    public int ProfissionalId { get; set; }
    public int ServicoId { get; set; }
}