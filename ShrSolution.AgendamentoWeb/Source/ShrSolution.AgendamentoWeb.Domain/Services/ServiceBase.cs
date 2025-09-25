using ShrSolution.AgendamentoWeb.Domain.Core;
using ShrSolution.AgendamentoWeb.Domain.Repositories;

namespace ShrSolution.AgendamentoWeb.Domain.Services;

public interface IServiceBase<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : struct
{
    //bool ExistePorId(TKey? pKey);
    TEntity? ObterPorId(TKey pKey);
    IQueryable<TEntity> ObterTodos();
    void Adicionar(TEntity pEntidade);
    void Atualizar(TEntity pEntidade);
    void Remover(TKey pId);
}

public class ServiceBase<TEntity, TKey> : IServiceBase<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : struct
{
    private IRepository<TEntity, TKey> _repository;

    public ServiceBase(IRepository<TEntity, TKey> repository)
    {
        _repository = repository;
    }

    // public bool ExistePorId(TKey? pKey)
    // {
    //     if(pKey == null)
    //         return false;
    //
    //     var xRetorno = ObterTodos()
    //             .Where(p => !p.Excluido)
    //             .Any(p => p.Id.Equals(pKey))
    //         ;
    //
    //     return xRetorno;
    // }

    public TEntity? ObterPorId(TKey pKey)
    {
        var xRetorno = ObterTodos()
            .FirstOrDefault(p => p.Id.Equals(pKey));

        return xRetorno;
    }

    public IQueryable<TEntity> ObterTodos()
    {
        var xRetorno = _repository.ObterTodos()
                .Where(p => !p.Excluido)
            ;

        return xRetorno;
    }

    public void Adicionar(TEntity pEntidade)
    {
        _repository.Adicionar(pEntidade);
    }

    public void Atualizar(TEntity pEntidade)
    {
        _repository.Atualizar(pEntidade);
    }

    public void Remover(TKey pId)
    {
        _repository.Remover(pId);
    }

    // public Task<int> SalvarAlteracoesAsync()
    // {
    //     throw new NotImplementedException();
    // }

    // public int SalvarAlteracoes()
    // {
    //     throw new NotImplementedException();
    // }
}