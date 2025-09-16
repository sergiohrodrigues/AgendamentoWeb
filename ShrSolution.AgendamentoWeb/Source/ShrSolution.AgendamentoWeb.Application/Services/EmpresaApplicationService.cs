using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.ViewModels;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Application.Services;

public class EmpresaApplicationService : IEmpresaApplicationService
{
    private readonly IEmpresaService _empresaService;
    private readonly IMapper _mapper;


    public EmpresaApplicationService(IEmpresaService empresaService, IMapper mapper)
    {
        _empresaService = empresaService;
        _mapper = mapper;
    }

    public async Task<EmpresaViewModel?> ObterEmpresaPorId(int pEmpresaId)
    {
        var xEmpresa = await _empresaService.ObterPorId(pEmpresaId);

        var xRetorno = _mapper.Map<EmpresaViewModel>(xEmpresa);

        return xRetorno;
    }

    public async Task<AdicionarEmpresaViewModel> Adicionar(AdicionarEmpresaViewModel pEmpresa)
    {
        var xEmpresa = _mapper.Map<Empresa>(pEmpresa);

        _empresaService.Adicionar(xEmpresa);

        return pEmpresa;
    }
}