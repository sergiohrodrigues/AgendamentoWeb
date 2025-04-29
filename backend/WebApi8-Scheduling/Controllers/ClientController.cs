//using Microsoft.AspNetCore.Mvc;
//using WebApi8_Scheduling.Dto.Client;
//using WebApi8_Scheduling.Models;
//using WebApi8_Scheduling.Services.Client;

//namespace WebApi8_Scheduling.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClientController : ControllerBase
//    {
//        private readonly IClientInterface _clientInterface;

//        public ClientController(IClientInterface clientInterface)
//        {
//            _clientInterface = clientInterface;
//        }

//        [HttpGet("GetAllClients")]
//        public async Task<ActionResult<ResponseModel<List<ClientModel>>>> GetAllClients(int idUser)
//        {
//            var client = await _clientInterface.GetAllClients(idUser);
//            return Ok(client);
//        }
        
//        [HttpPost("CreateClient")]
//        public async Task<ActionResult<ResponseModel<ClientModel>>> CreateClient(ClientCreateDto clientCreateDto)
//        {
//            var client = await _clientInterface.CreateClient(clientCreateDto);
//            return Ok(client);
//        }
        
//        [HttpPut("UpdateClient")]
//        public async Task<ActionResult<ResponseModel<ClientModel>>> UpdateClient(ClientUpdateDto clientUpdateDto)
//        {
//            var client = await _clientInterface.UpdateClient(clientUpdateDto);
//            return Ok(client);
//        }
        
//        [HttpDelete("DeleteClient")]
//        public async Task<ActionResult<ResponseModel<ClientModel>>> DeleteClient(int idClient)
//        {
//            var client = await _clientInterface.DeleteClient(idClient);
//            return Ok(client);
//        }


//    }
//}
