using Microsoft.AspNetCore.Mvc;
using ShrSolution.AgendamentoWeb.Application.Dto.Client;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.Response;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Services.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationService;

        public ClientController(IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        // [HttpGet]
        // public async Task<ActionResult<ResponseModel<List<ClienteViewModel>>>> ObterTodosClientes()
        // {
        //     var client = _clienteApplicationService.ObterTodosClientes();
        //     return Ok(client);
        // }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<ResponseModel<ClienteViewModel>>> ObterClientePorId(int clientId)
        {
            try
            {
                var xCliente = await _clienteApplicationService.ObterClientePorId(clientId);
                return Ok(xCliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseModel<AdicionarClienteViewModel>>> Adicionar(AdicionarClienteViewModel pClient)
        {
            try
            {
                var xCliente = await _clienteApplicationService.Adicionar(pClient);
                return Ok(xCliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpPut("{clientId}")]
        // public async Task<ActionResult<ResponseModel<Cliente>>> UpdateClient(int clientId, ClientUpdateDto pClient)
        // {
        //     var client = await _clienteInterface.UpdateClient(clientId, pClient);
        //     return Ok(client);
        // }
        //
        // [HttpDelete("{clientId}")]
        // public async Task<ActionResult<ResponseModel<Cliente>>> DeleteClient(int clientId)
        // {
        //     var client = await _clienteInterface.DeleteClient(clientId);
        //     return Ok(client);
        // }


    }
}
