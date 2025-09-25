
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Repositories;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Domain.Services
{
    public class ServicoService : ServiceBase<Servico, int>, IServicoService
    {
        public ServicoService(IRepository<Servico, int> repository) : base(repository)
        {
        }
    }
}
