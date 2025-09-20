using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AgendamentoWebContext _context;

    public ClienteRepository(AgendamentoWebContext context)
    {
        _context = context;
    }

    public async Task<Cliente?> ObterPorId(int pClienteId)
    {
        return await _context.Cliente.FindAsync(pClienteId);
    }

    public void Adicionar(Cliente pCliente)
    {
        _context.Add(pCliente);
        _context.SaveChanges();
    }
}