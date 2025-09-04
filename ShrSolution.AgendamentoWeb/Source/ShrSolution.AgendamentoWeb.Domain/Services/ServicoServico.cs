// using Microsoft.EntityFrameworkCore;
// using ShrSolution.AgendamentoWeb.Domain.Models;
// using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;
// using WebApi8_Scheduling.Domain.Services.Interfaces;
// using WebApi8_Scheduling.Dto.Service;
// using WebApi8_Scheduling.Infra.Data;
//
// namespace WebApi8_Scheduling.Domain.Services
// {
//     public class ServicoServico : IServicoInterface
//     {
//         private readonly AppDbContext _context;
//         public ServicoServico(AppDbContext context)
//         {
//             _context = context;
//         }
//
//         public async Task<ResponseModel<Servico>> CreateService(CriarServicoDto pService)
//         {
//             ResponseModel<Servico> respost = new ResponseModel<Servico>();
//
//             try
//             {
//                 var xEnterprise = await _context.Empresa.FirstOrDefaultAsync(p => p.Id == pService.EmpresaId);
//
//                 if (xEnterprise == null)
//                 {
//                     respost.Mensagem = "Enteprise not found";
//                     return respost;
//                 }
//
//                 var xNewService = new Servico
//                 {
//                     Nome = pService.Nome,
//                     Descricao = pService.Descricao,
//                     Valor = pService.Valor,
//                     EmpresaId = pService.EmpresaId,
//                 };
//
//                 _context.Servico.Add(xNewService);
//                 _context.SaveChanges();
//
//                 respost.Dados = xNewService;
//                 respost.Mensagem = "Service created successfull!";
//                 return respost;
//
//             }
//             catch (Exception ex)
//             {
//                 respost.Mensagem = ex.Message;
//                 respost.Status = false;
//                 return respost;
//             }
//         }
//     }
// }
