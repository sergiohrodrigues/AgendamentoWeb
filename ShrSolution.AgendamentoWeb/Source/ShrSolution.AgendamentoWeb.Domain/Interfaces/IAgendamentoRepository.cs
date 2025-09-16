using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Interfaces;

public interface IAgendamentoRepository
{
    Task<Agendamento> AdicionarAgendamento(Agendamento agendamento);
}