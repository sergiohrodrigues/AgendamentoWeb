namespace ShrSolution.AgendamentoWeb.Domain.Repositories;

public interface IRepository<TKey, TEntity>
{
    TEntity? ObterPorId(TKey id);
    void Adicionar(TEntity pEntity);
    IQueryable<TEntity> ObterTodos();
    void Atualizar(TEntity pEntidade);
    //void Excluir(TEntity pEntidade);
    void Remover(TKey pId);
}