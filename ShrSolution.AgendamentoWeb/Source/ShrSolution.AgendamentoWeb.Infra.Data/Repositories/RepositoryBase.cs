using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class RepositoryBase
{
    private readonly AgendamentoWebContext _context;

    public RepositoryBase(AgendamentoWebContext context)
    {
        _context = context;
    }
    
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}