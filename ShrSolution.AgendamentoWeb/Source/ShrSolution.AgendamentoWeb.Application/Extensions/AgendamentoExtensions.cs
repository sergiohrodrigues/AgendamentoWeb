using ShrSolution.AgendamentoWeb.Application.ViewModels.Agendamento;

namespace ShrSolution.AgendamentoWeb.Application.Extensions;

public static class AgendamentoExtensions
{
    public static bool horarioDisponivel(this IEnumerable<AgendamentoViewModel> agendamentos, DateTime horario)
    {
        return !agendamentos.Any(a => a.Data == horario);
    }

}