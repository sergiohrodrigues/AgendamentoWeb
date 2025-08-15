using System.Net.Mail;
using System.Text.RegularExpressions;
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
                if (string.IsNullOrWhiteSpace(pCliente.Nome) || pCliente.Nome.Length < 3)
                    throw new Exception("Por favor insira um nome com mais de 3 caracteres!");

                if (!TelefoneValido(pCliente.Telefone))
                    throw new Exception("Telefone inválido, por favor insira um telefone válido!");
                
                if (!EmailValido(pCliente.Email))
                    throw new Exception("E-mail inválido, por favor insira um e-mail válido!");
                
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
                    respost.Mensagem = "Usuário não encontrado!";
                    return respost;
                }
                
                if (string.IsNullOrWhiteSpace(clientUpdateDto.Nome) || clientUpdateDto.Nome.Length < 3)
                    throw new Exception("Por favor insira um nome com mais de 3 caracteres!");

                if (!TelefoneValido(clientUpdateDto.Telefone))
                    throw new Exception("Telefone inválido, por favor insira um telefone válido!");
                
                if (!EmailValido(clientUpdateDto.Email))
                    throw new Exception("E-mail inválido, por favor insira um e-mail válido!");

                user.Nome = clientUpdateDto.Nome;
                user.Telefone = clientUpdateDto.Telefone;
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
        
        private bool EmailValido(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                
                string dominio = mail.Host.ToLower();
                
                return mail.Address == email &&
                       (dominio.EndsWith(".com") || dominio.EndsWith(".br"));
            }
            catch
            {
                return false;
            }
        }
        
        private bool TelefoneValido(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            string padrao = @"^\(?[1-9]{2}\)?\s?(9?[0-9]{4})-?[0-9]{4}$";

            var xRetorno = Regex.IsMatch(telefone, padrao);
            return xRetorno;
        }

    }
}
