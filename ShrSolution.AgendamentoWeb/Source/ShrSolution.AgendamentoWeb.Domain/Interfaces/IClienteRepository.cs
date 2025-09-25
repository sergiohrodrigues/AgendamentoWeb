using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Repositories;

namespace ShrSolution.AgendamentoWeb.Domain.Interfaces;

public interface IClienteRepository : IRepository<Cliente, int>
{
}