using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;
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
        var xCliente = _clienteService.ObterPorId(pClienteId);

        if (xCliente == null)
            throw new Exception("Cliente não encontrado.");

        var xRetorno = _mapper.Map<ClienteViewModel>(xCliente);

        return xRetorno;
    }

    public List<ClienteViewModel> ObterTodosClientes()
    {
        var xRetorno = _clienteService.ObterTodos()
            .ProjectTo<ClienteViewModel>(_mapper.ConfigurationProvider)
            .ToList()
        ;

        return xRetorno;
    }

    public async Task<AdicionarClienteViewModel> AdicionarCliente(AdicionarClienteViewModel pClienteViewModel)
    {
        var xRetorno = _mapper.Map<Cliente>(pClienteViewModel);

        _clienteService.Adicionar(xRetorno);

        return pClienteViewModel;
    }

    public async Task<EditarClienteViewModel> EditarCliente(int pClienteId, EditarClienteViewModel pEditarClienteViewModel)
    {
        var xCliente = _clienteService.ObterPorId(pClienteId);
        if (xCliente == null)
            throw new Exception("Cliente não encontrado.");

        xCliente.Nome = pEditarClienteViewModel.Nome;
        xCliente.Email = pEditarClienteViewModel.Email;
        xCliente.Telefone = pEditarClienteViewModel.Telefone;

        _clienteService.Atualizar(xCliente);

        return pEditarClienteViewModel;
    }

    public async Task<bool> RemoverCliente(int pClienteId)
    {
        var xCliente = _clienteService.ObterPorId(pClienteId);
        if (xCliente == null)
            throw new Exception("Cliente não encontrado.");

        _clienteService.Remover(xCliente.Id);

        return true;
    }
}