using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Repositories;

namespace ShrSolution.AgendamentoWeb.Domain.Interfaces;

public interface IAgendamentoRepository : IRepository<Agendamento, int>
{
}