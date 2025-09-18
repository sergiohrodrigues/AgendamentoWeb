using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Interfaces;

public interface IProfissionalRepository
{
    Task<Profissional?> ObterPorId(int id);
    public void Adicionar(Profissional pProfissional);
    Task<IEnumerable<Profissional>> GetAllAsync();
}