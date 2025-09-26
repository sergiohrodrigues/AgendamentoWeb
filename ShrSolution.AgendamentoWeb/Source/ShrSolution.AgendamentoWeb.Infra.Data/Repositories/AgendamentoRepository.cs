using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class AgendamentoRepository : Repository<Agendamento, int>, IAgendamentoRepository
{
    public AgendamentoRepository(AgendamentoWebContext context) : base(context)
    {
    }
}