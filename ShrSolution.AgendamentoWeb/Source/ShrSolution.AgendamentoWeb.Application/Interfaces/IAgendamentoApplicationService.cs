using ShrSolution.AgendamentoWeb.Application.ViewModels.Agendamento;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IAgendamentoApplicationService
{
    Task<AgendamentoViewModel> ObterAgendamentoPorId(int pAgendamentoId);
    Task<AdicionarAgendamentoViewModel> Adicionar(AdicionarAgendamentoViewModel pAdicionarAgendamentoViewModel);
    public List<AgendamentoViewModel> ObterTodosAgendamentos();
}