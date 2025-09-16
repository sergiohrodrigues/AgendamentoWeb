using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Interfaces;

public interface IEmpresaRepository
{
    Task<Empresa?> ObterPorId(int id);
    void Adicionar(Empresa pEmpresa);
}