using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Application.Services;

public class ProfissionalApplicationService : IProfissionalApplicationService
{
    private readonly IProfissionalService _profissionalService;
    private readonly IEmpresaService _empresaService;
    private readonly IMapper _mapper;

    public ProfissionalApplicationService(IProfissionalService profissionalService, IEmpresaService empresaService, IMapper mapper)
    {
        _profissionalService = profissionalService;
        _empresaService = empresaService;
        _mapper = mapper;
    }

    public async Task<AdicionarProfissionalViewModel?> Adicionar(AdicionarProfissionalViewModel pAdicionarProfissionalViewModel)
    {
        if (pAdicionarProfissionalViewModel.EmpresaId == null)
            throw new Exception("Empresa é obrigatório");

        var xEmpresa = await _empresaService.ObterPorId(pAdicionarProfissionalViewModel.EmpresaId!.Value);

        if (xEmpresa == null)
            throw new Exception("Empresa não encontrada");

        var xRetorno = _mapper.Map<Profissional>(pAdicionarProfissionalViewModel);
        _profissionalService.Adicionar(xRetorno);

        return pAdicionarProfissionalViewModel;
    }
}