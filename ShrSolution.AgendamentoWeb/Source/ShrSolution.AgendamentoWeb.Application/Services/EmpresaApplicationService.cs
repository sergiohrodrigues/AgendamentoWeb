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
        var xEmpresa = _empresaService.ObterPorId(pEmpresaId);
        if (xEmpresa == null)
            throw new Exception("Empresa não encontrada");

        var xRetorno = _mapper.Map<EmpresaViewModel>(xEmpresa);

        return xRetorno;
    }

    public Task<AdicionarEmpresaViewModel> Adicionar(AdicionarEmpresaViewModel pEmpresa)
    {
        if (pEmpresa.Nome == null)
            throw new Exception("Nome não pode ser nulo");

        if(pEmpresa.Telefone == null)
            throw new Exception("Telefone não pode ser nulo");

        if(pEmpresa.Endereco == null)
            throw new Exception("Endereço não pode ser nulo");

        var xEmpresa = _mapper.Map<Empresa>(pEmpresa);

        _empresaService.Adicionar(xEmpresa);

        return Task.FromResult(pEmpresa);
    }
}