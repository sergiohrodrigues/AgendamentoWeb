using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.Extensions;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Agendamento;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Application.Services;

public class AgendamentoApplicationService : IAgendamentoApplicationService
{
    private readonly IAgendamentoService _agendamentoService;
    private readonly IProfissionalService _profissionalService;
    private readonly IClienteService _clienteService;
    private readonly IEmpresaService _empresaService;
    private readonly IServicoService _servicoService;
    private readonly IMapper _mapper;

    public AgendamentoApplicationService(
        IAgendamentoService agendamentoService
        , IProfissionalService profissionalService
        , IClienteService clienteService
        , IEmpresaService empresaService
        , IServicoService servicoService, IMapper mapper)
    {
        _agendamentoService = agendamentoService;
        _profissionalService = profissionalService;
        _clienteService = clienteService;
        _empresaService = empresaService;
        _servicoService = servicoService;
        _mapper = mapper;
    }
        public Task<AgendamentoViewModel> ObterAgendamentoPorId(int pAgendamentoId)
        {
            var xAgendamento = _agendamentoService.ObterPorId(pAgendamentoId);
            
            if (xAgendamento == null)
                throw new Exception("Agendamento não encontrado.");

            var xRetorno = _mapper.Map<AgendamentoViewModel>(xAgendamento);
            return Task.FromResult(xRetorno);
        }

        public Task<AdicionarAgendamentoViewModel> Adicionar(
            AdicionarAgendamentoViewModel pAdicionarAgendamentoViewModel)
        {
            var xServico = _servicoService.ObterPorId(pAdicionarAgendamentoViewModel.ServicoId);

            if (xServico == null)
                throw new Exception("Serviço não encontrado.");

            var xEmpresa =  _empresaService.ObterPorId(pAdicionarAgendamentoViewModel.EmpresaId);

            if (xEmpresa == null)
                throw new Exception("Empresa não encontrada.");

            var xCliente =  _clienteService.ObterPorId(pAdicionarAgendamentoViewModel.ClienteId);

            if (xCliente == null)
                throw new Exception("Cliente não encontrado.");

            var xProfissional =  _profissionalService.ObterPorId(pAdicionarAgendamentoViewModel.ProfissionalId);

            if (xProfissional == null)
                throw new Exception("Profissinoal não encontrado.");

            if(pAdicionarAgendamentoViewModel.Data.EhDomingo())
                throw new Exception("Não é possível agendar no Domingo.");

            if(!pAdicionarAgendamentoViewModel.Data.EhHorarioDeTrabalho())
                throw new Exception("Não é possível agendar fora do horário de expediente.");

            var newAgendamento = new Agendamento
            {
                Data = pAdicionarAgendamentoViewModel.Data,
                Observacao = pAdicionarAgendamentoViewModel.Observacao,
                ServicoId = pAdicionarAgendamentoViewModel.ServicoId,
                EmpresaId = pAdicionarAgendamentoViewModel.EmpresaId,
                ClienteId = pAdicionarAgendamentoViewModel.ClienteId,
                ProfissionalId = pAdicionarAgendamentoViewModel.ProfissionalId
            };

            _agendamentoService.Adicionar(newAgendamento);

            return Task.FromResult(pAdicionarAgendamentoViewModel);
        }

        public List<AgendamentoViewModel> ObterTodosAgendamentos()
        {
            var xAgendamentos = _agendamentoService.ObterTodos()
                .ToList();

            var xRetorno = _mapper.Map<List<AgendamentoViewModel>>(xAgendamentos);
            return xRetorno;
        }
}