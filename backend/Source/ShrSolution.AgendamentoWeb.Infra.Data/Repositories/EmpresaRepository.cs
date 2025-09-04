using Microsoft.EntityFrameworkCore;
using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly AgendamentosContext _context;

    public EmpresaRepository(AgendamentosContext context)
    {
        _context = context;
    }

    public async Task<Empresa?> ObterPorId(int id)
    {
        var xRetorno = await _context.Empresa.FindAsync(id);

        return xRetorno;
    }
}