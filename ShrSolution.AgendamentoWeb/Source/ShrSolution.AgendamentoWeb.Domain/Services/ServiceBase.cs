namespace ShrSolution.AgendamentoWeb.Domain.Services;

public interface IServiceBase<TEntity, TKey>
{
    void Adicionar(TEntity pEntidade);
}

public class ServiceBase<TEntity, TKey> : IServiceBase<TEntity, TKey>
{
    // private IRepository
    public void Adicionar(TEntity pEntidade)
    {
        throw new NotImplementedException();
    }
}