namespace ShrSolution.AgendamentoWeb.Domain.Core;

public class Entity
{
    public bool Excluido { get; set; } = false;
    public DateTime CriadoDataHora { get; set; } = DateTime.UtcNow;
}

public abstract class Entity<T> : Entity
{
    public T Id { get; set; }
}