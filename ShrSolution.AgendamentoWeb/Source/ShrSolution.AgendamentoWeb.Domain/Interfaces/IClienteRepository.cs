using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Interfaces;

public interface IClienteRepository
{
    Task<Cliente?> ObterPorId(int id);
    void Adicionar(Cliente pCliente);
}