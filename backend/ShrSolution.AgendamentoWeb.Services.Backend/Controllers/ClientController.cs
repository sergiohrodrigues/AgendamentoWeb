// using Microsoft.AspNetCore.Mvc;
// using WebApi8_Scheduling.Domain.Models;
// using WebApi8_Scheduling.Domain.Services.Interfaces;
// using WebApi8_Scheduling.Dto.Client;
//
// namespace WebApi8_Scheduling.Services.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ClientController : ControllerBase
//     {
//         private readonly IClienteInterface _clienteInterface;
//
//         public ClientController(IClienteInterface clienteInterface)
//         {
//             _clienteInterface = clienteInterface;
//         }
//
//         //[HttpGet]
//         //public async Task<ActionResult<ResponseModel<List<ClientModel>>>> GetAllClients(int pClientId)
//         //{
//         //    var client = await _clientInterface.GetAllClients(pClientId);
//         //    return Ok(client);
//         //}
//
//         [HttpPost]
//         public async Task<ActionResult<ResponseModel<Cliente>>> CriarCliente(CriarClienteDto pClient)
//         {
//             var cliente = await _clienteInterface.CriarCliente(pClient);
//             return Ok(cliente);
//         }
//
//         [HttpPut("{clientId}")]
//         public async Task<ActionResult<ResponseModel<Cliente>>> UpdateClient(int clientId, ClientUpdateDto pClient)
//         {
//             var client = await _clienteInterface.UpdateClient(clientId, pClient);
//             return Ok(client);
//         }
//
//         [HttpDelete("{clientId}")]
//         public async Task<ActionResult<ResponseModel<Cliente>>> DeleteClient(int clientId)
//         {
//             var client = await _clienteInterface.DeleteClient(clientId);
//             return Ok(client);
//         }
//
//
//     }
// }
