using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository context)
        {
            _empresaRepository = context;
        }

        public async Task<Empresa?> ObterPorId(int pEmpresaId)
        {
            var xRetorno = await _empresaRepository.ObterPorId(pEmpresaId);

            if (xRetorno == null)
                throw new Exception("Empresa não encontrada");

            return xRetorno;
        }

        public void Adicionar(Empresa pEmpresa)
        {
            if (pEmpresa.Nome == null)
                throw new Exception("Nome não pode ser nulo");

            if(pEmpresa.Telefone == null)
                throw new Exception("Telefone não pode ser nulo");

            if(pEmpresa.Endereco == null)
                throw new Exception("Endereço não pode ser nulo");

            _empresaRepository.Adicionar(pEmpresa);
        }

        // public async Task<ResponseModel<Empresa>> CreateEnterprise(EnterpriseCreateDto userCreateDto)
        // {
        //     ResponseModel<Empresa> respost = new ResponseModel<Empresa>();
        //
        //     try
        //     {
        //         var newEnterprise = new Empresa
        //         {
        //             Nome = userCreateDto.Nome,
        //             Cnpj = userCreateDto.Cnpj,
        //             Email = userCreateDto.Email,
        //             Telefone = userCreateDto.Telefone,
        //             Endereco = userCreateDto.Endereco,
        //         };
        //
        //         _context.Empresa.Add(newEnterprise);
        //         _context.SaveChanges();
        //
        //         respost.Dados = newEnterprise;
        //
        //         respost.Mensagem = "Enterprise create successfull!";
        //         return respost;
        //
        //     }
        //     catch (Exception ex)
        //     {
        //         respost.Mensagem = ex.Message;
        //         respost.Status = false;
        //         return respost;
        //     }
        // }
        //
        // public async Task<ResponseModel<Empresa>> LoginEnterprise(EnterpriseLoginDto userLoginDto)
        // {
        //     ResponseModel<Empresa> respost = new ResponseModel<Empresa>();
        //
        //     try
        //     {
        //         //var user = await _context.Enterprise
        //         //    .FirstOrDefaultAsync(userBanco =>
        //         //        userBanco.Login == userLoginDto.Login &&
        //         //        userBanco.Password == userLoginDto.Password);
        //
        //         //if (user == null)
        //         //{
        //         //    var loginExists = await _context.Enterprise
        //         //        .AnyAsync(userBanco => userBanco.Login == userLoginDto.Login);
        //
        //         //    respost.Mensagem = loginExists ? "Incorrect password" : "Login not found";
        //         //    respost.Status = false;
        //         //    return respost;
        //         //}
        //
        //         //respost.Dados = new EnterpriseModel
        //         //{
        //         //    Id = user.Id,
        //         //    Login = user.Login,
        //         //    Email = user.Email
        //         //};
        //
        //         respost.Mensagem = "Login successful!";
        //         respost.Status = true;
        //         return respost;
        //     }
        //     catch (Exception ex)
        //     {
        //         respost.Mensagem = ex.Message;
        //         respost.Status = false;
        //         return respost;
        //     }
        // }
    }
}
