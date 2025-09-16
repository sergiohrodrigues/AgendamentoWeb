using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;

namespace ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

public class AgendamentoRepository : IAgendamentoRepository
{
    private readonly AgendamentoWebContext _context;

    public AgendamentoRepository(AgendamentoWebContext context)
    {
        _context = context;
    }

    public async Task<Agendamento> AdicionarAgendamento(Agendamento agendamento)
    {
        await _context.Agendamento.AddAsync(agendamento);
        await _context.SaveChangesAsync();

        return agendamento;
    }
}