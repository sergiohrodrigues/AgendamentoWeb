using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class ProfissionalRepository : Repository<Profissional, int>, IProfissionalRepository
{
    public ProfissionalRepository(AgendamentoWebContext context) : base(context)
    {
    }
}