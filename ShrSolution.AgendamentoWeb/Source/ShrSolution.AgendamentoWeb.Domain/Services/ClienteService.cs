using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Domain.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente?> ObterPorId(int pClienteId)
    {
        var xRetorno = _clienteRepository.ObterPorId(pClienteId);
        
        if (xRetorno == null)
            throw new Exception("Cliente não encontrado");

        return xRetorno;
    }

    public void Adicionar(Cliente pCliente)
    {
        if (pCliente.Nome == null)
            throw new Exception("Nome é de preenchimento obrigatório.");

        if(pCliente.Telefone == null)
            throw new Exception("Telefone é de preenchimento obrigatório.");

        if(pCliente.Email == null)
            throw new Exception("Email é de preenchimento obrigatório.");

        _clienteRepository.Adicionar(pCliente);
    }
}