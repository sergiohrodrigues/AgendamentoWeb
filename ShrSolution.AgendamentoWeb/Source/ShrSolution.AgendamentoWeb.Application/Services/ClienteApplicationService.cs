using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;
using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Application.Services;

public class ClienteApplicationService : IClienteApplicationService
{
    private readonly IClienteService _clienteService;
    private readonly IMapper _mapper;

    public ClienteApplicationService(IClienteService clienteService, IMapper mapper)
    {
        _clienteService = clienteService;
        _mapper = mapper;
    }

    public async Task<ClienteViewModel?> ObterClientePorId(int pClienteId)
    {
        var xCliente = await _clienteService.ObterPorId(pClienteId);

        if (xCliente == null)
            throw new Exception("Cliente não encontrado.");

        var xRetorno = _mapper.Map<ClienteViewModel>(xCliente);

        return xRetorno;
    }

    public async Task<AdicionarClienteViewModel> Adicionar(AdicionarClienteViewModel pClienteViewModel)
    {
        var xRetorno = _mapper.Map<Cliente>(pClienteViewModel);

        _clienteService.Adicionar(xRetorno);

        return pClienteViewModel;
    }
}