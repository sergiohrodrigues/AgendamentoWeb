using Microsoft.EntityFrameworkCore;
using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly AgendamentoWebContext _context;

    public EmpresaRepository(AgendamentoWebContext context)
    {
        _context = context;
    }

    public async Task<Empresa?> ObterPorId(int id)
    {
        var xRetorno = await _context.Empresa.FindAsync(id);

        return xRetorno;
    }

    public void Adicionar(Empresa pEmpresa)
    {
        _context.Add(pEmpresa);
        _context.SaveChanges();
    }
}