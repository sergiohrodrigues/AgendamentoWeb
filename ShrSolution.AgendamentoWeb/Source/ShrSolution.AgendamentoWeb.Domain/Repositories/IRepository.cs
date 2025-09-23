namespace ShrSolution.AgendamentoWeb.Domain.Repositories;

public interface IRepository<TKey, TEntity>
{
    TEntity? ObterPorId(TKey id);
    void Adicionar(TEntity pEntity);
    IQueryable<TEntity> ObterTodos();
}