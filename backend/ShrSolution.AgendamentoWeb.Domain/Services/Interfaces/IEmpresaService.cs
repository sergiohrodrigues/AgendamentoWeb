using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Domain.Services.Interfaces
{
    public interface IEmpresaService
    {
        public Task<Empresa?> ObterPorId(int id);
    }
}
