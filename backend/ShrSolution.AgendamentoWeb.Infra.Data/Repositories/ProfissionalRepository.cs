using Microsoft.EntityFrameworkCore;
using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class ProfissionalRepository : IProfissionalRepository
{
    private readonly AgendamentosContext _context;

    public ProfissionalRepository(AgendamentosContext context)
    {
        _context = context;
    }

    public async Task<Profissional?> ObterPorId(int id)
    {
        var xRetorno = await _context.Profissional.FindAsync(id);

        return  xRetorno;
    }

    public async Task<Profissional> AddAsync(Profissional pProfissional)
    {
        _context.Profissional.Add(pProfissional);
        await _context.SaveChangesAsync();
        return pProfissional;
    }

    public async Task<IEnumerable<Profissional>> GetAllAsync()
    {
        return await _context.Profissional.ToListAsync();
    }
}