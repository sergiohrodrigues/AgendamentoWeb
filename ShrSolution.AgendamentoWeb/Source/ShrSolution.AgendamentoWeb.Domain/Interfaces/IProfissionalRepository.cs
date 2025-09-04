using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Interfaces;

public interface IProfissionalRepository
{
    Task<Profissional?> ObterPorId(int id);
    Task<Profissional> AddAsync(Profissional pProfissional);
    Task<IEnumerable<Profissional>> GetAllAsync();
}