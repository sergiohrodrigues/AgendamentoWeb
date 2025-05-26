using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.Client;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Cliente
{
    public class ClienteService : IClienteInterface
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ClienteModel>>> GetAllClients(int idUser)
        {
            ResponseModel<List<ClienteModel>> respost = new ResponseModel<List<ClienteModel>>();

            try
            {
                var clients = await _context.Cliente
                    .ToListAsync();

                if (!clients.Any())
                {
                    respost.Mensagem = "User not found!";
                    return respost;
                }

                respost.Mensagem = "Get all clients successfully!";
                respost.Dados = clients;
                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<ClienteModel>> CriarCliente(CriarClienteDto pCliente)
        {

            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();

            try
            {
                var novoCliente = new ClienteModel()
                {
                    Nome = pCliente.Nome,
                    Telefone = pCliente.Telefone,
                    Email = pCliente.Email
                };

                _context.Cliente.Add(novoCliente);
                _context.SaveChanges();

                resposta.Dados = novoCliente;
                resposta.Mensagem = "Cliente adicionado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> UpdateClient(int clientId, ClientUpdateDto clientUpdateDto)
        {
            ResponseModel<ClienteModel> respost = new ResponseModel<ClienteModel>();

            try
            {
                var user = await _context.Cliente.FirstOrDefaultAsync(a => a.Id == clientId);

                if (user == null)
                {
                    respost.Mensagem = "User not found!";
                    return respost;
                }

                user.Nome = clientUpdateDto.Name;
                user.Telefone = clientUpdateDto.Tel;
                user.Email = clientUpdateDto.Email;

                _context.Cliente.Update(user);
                _context.SaveChanges();

                respost.Dados = user;
                respost.Mensagem = "User Updated successfully!";

                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<ClienteModel>> DeleteClient(int idClient)
        {
            ResponseModel<ClienteModel> respost = new ResponseModel<ClienteModel>();

            try
            {
                var client = await _context.Cliente.FirstOrDefaultAsync(clientBanco => clientBanco.Id == idClient);

                if (client == null)
                {
                    respost.Mensagem = "Client not found!";
                    return respost;
                }

                _context.Cliente.Remove(client);
                _context.SaveChanges();

                respost.Dados = client;
                respost.Mensagem = "User Deleted successfully!";

                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }
    }
}
