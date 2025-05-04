using Microsoft.AspNetCore.Mvc;
using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Models;
using WebApi8_Scheduling.Services.Client;

namespace WebApi8_Scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientInterface _clientInterface;

        public ClientController(IClientInterface clientInterface)
        {
            _clientInterface = clientInterface;
        }

        //[HttpGet]
        //public async Task<ActionResult<ResponseModel<List<ClientModel>>>> GetAllClients(int pClientId)
        //{
        //    var client = await _clientInterface.GetAllClients(pClientId);
        //    return Ok(client);
        //}

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ClientModel>>> CreateClient(ClientCreateDto pClient)
        {
            var client = await _clientInterface.CreateClient(pClient);
            return Ok(client);
        }

        [HttpPut("{clientId}")]
        public async Task<ActionResult<ResponseModel<ClientModel>>> UpdateClient(int clientId, ClientUpdateDto pClient)
        {
            var client = await _clientInterface.UpdateClient(clientId, pClient);
            return Ok(client);
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseModel<ClientModel>>> DeleteClient(int pCLientId)
        {
            var client = await _clientInterface.DeleteClient(pCLientId);
            return Ok(client);
        }


    }
}
