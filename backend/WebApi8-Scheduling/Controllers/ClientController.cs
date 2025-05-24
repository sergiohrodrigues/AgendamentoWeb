using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.Cliente;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClientController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        //[HttpGet]
        //public async Task<ActionResult<ResponseModel<List<ClientModel>>>> GetAllClients(int pClientId)
        //{
        //    var client = await _clientInterface.GetAllClients(pClientId);
        //    return Ok(client);
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> CriarCliente(CriarClienteDto pClient)
        {
            var cliente = await _clienteInterface.CriarCliente(pClient);
            return Ok(cliente);
        }

        [HttpPut("{clientId}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> UpdateClient(int clientId, ClientUpdateDto pClient)
        {
            var client = await _clienteInterface.UpdateClient(clientId, pClient);
            return Ok(client);
        }

        [HttpDelete("{clientId}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> DeleteClient(int clientId)
        {
            var client = await _clienteInterface.DeleteClient(clientId);
            return Ok(client);
        }


    }
}
