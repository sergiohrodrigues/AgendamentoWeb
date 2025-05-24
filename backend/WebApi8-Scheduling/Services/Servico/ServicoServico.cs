
using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.Service;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Servico
{
    public class ServicoServico : IServicoInterface
    {
        private readonly AppDbContext _context;
        public ServicoServico(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ServicoModel>> CreateService(CriarServicoDto pService)
        {
            ResponseModel<ServicoModel> respost = new ResponseModel<ServicoModel>();

            try
            {
                var xEnterprise = await _context.Empresa.FirstOrDefaultAsync(p => p.Id == pService.EmpresaId);

                if (xEnterprise == null)
                {
                    respost.Mensagem = "Enteprise not found";
                    return respost;
                }

                var xNewService = new ServicoModel
                {
                    Nome = pService.Nome,
                    Descricao = pService.Descricao,
                    Valor = pService.Valor,
                    EmpresaId = pService.EmpresaId,
                };

                _context.Servico.Add(xNewService);
                _context.SaveChanges();

                respost.Dados = xNewService;
                respost.Mensagem = "Service created successfull!";
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
