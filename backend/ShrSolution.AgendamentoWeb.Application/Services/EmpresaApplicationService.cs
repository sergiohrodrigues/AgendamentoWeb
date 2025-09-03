using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.ViewModels;
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

        if (xEmpresa == null)
            throw new Exception("Empresa não encontrada");

        var xRetorno = _mapper.Map<EmpresaViewModel>(xEmpresa);

        return xRetorno;
    }
}