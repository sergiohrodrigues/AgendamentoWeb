using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Repositories;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Domain.Services
{
    public class AgendamentoService : ServiceBase<Agendamento, int>, IAgendamentoService
    {
        public AgendamentoService(IRepository<Agendamento, int> repository) : base(repository)
        {
        }
    }
}
