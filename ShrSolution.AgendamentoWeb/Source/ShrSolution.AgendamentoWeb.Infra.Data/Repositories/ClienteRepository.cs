using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class ClienteRepository : Repository<int, Cliente>, IClienteRepository
{
    public ClienteRepository(AgendamentoWebContext context) : base(context)
    {
    }
}