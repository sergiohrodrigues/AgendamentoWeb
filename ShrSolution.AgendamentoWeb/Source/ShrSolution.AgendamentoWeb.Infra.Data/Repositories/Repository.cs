using Microsoft.EntityFrameworkCore;
using ShrSolution.AgendamentoWeb.Domain.Repositories;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class Repository<TKey, TEntity> 
    : RepositoryBase , IRepository<TKey, TEntity>
    where TEntity : class
{
    protected readonly DbSet<TEntity> DbSet;

    public Repository(AgendamentoWebContext context) : base(context)
    {
        DbSet = context.Set<TEntity>();
    }

    public TEntity? ObterPorId(TKey pId)
    {
        return DbSet.Find(pId);
    }

    public void Adicionar(TEntity pEntity)
    {
        DbSet.Add(pEntity);
        SaveChanges();
    }

    public IQueryable<TEntity> ObterTodos()
    {
        return DbSet;
    }

    public void Atualizar(TEntity pEntidade)
    {
        DbSet.Update(pEntidade);
        SaveChanges();
    }

    // public void Excluir(TEntity pEntidade)
    // {
    //     DbSet.Update(pEntidade);
    //     SaveChanges();
    // }

    public void Remover(TKey pId)
    {
        DbSet.Remove(DbSet.Find(pId));
        SaveChanges();
    }
}