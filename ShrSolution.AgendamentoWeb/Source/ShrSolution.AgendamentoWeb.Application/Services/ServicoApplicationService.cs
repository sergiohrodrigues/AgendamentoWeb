using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Servico;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Application.Services;

public class ServicoApplicationService : IServicoApplicationService
{
    private readonly IServicoService _servicoService;
    private readonly IMapper _mapper;

    public ServicoApplicationService(IServicoService servicoService, IMapper mapper)
    {
        _servicoService = servicoService;
        _mapper = mapper;
    }

    public async Task<ServicoViewModel?> ObterServicoPorId(int pServicoId)
    {
        var xServico = _servicoService.ObterPorId(pServicoId);
        if (xServico == null)
            throw new Exception("Serviço não encontrado.");

        var xRetorno = _mapper.Map<ServicoViewModel>(xServico);

        return xRetorno;
    }

    public async Task<AdicionarServicoViewModel?> Adicionar(AdicionarServicoViewModel pAdicionarServicoViewModel)
    {
        if (pAdicionarServicoViewModel.EmpresaId == null)
            throw new Exception("Empresa é obrigatório");

        var xEmpresa = _servicoService.ObterPorId(pAdicionarServicoViewModel.EmpresaId);

        if (xEmpresa == null)
            throw new Exception("Empresa não encontrada");

        var xServico = _mapper.Map<Servico>(pAdicionarServicoViewModel);
        _servicoService.Adicionar(xServico);

        return pAdicionarServicoViewModel;
    }
}