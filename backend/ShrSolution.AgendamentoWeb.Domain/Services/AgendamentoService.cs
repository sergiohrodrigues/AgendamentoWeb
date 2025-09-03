// using ShrSolution.AgendamentoWeb.Application.Dto.Scheduling;
// using ShrSolution.AgendamentoWeb.Domain.Models;
// using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;
//
// namespace WebApi8_Scheduling.Domain.Services
// {
//     public class AgendamentoService : IAgendamentoInterface
//     {
//         private readonly AppDbContext _context;
//         public AgendamentoService(AppDbContext context)
//         {
//             _context = context;
//         }
//         public async Task<ResponseModel<Agendamento>> CreateSheduling(SchedulingCreateDto schedulingCreateDto)
//         {
//             ResponseModel<Agendamento> respost = new ResponseModel<Agendamento>();
//
//             try
//             {
//                 var serviceId = await _context.Servico.FirstOrDefaultAsync(serviceBanco => serviceBanco.Id == schedulingCreateDto.ServicoId);
//
//                 if (serviceId == null)
//                 {
//                     respost.Mensagem = "Service not found";
//                     return respost;
//                 }
//
//                 var enterprise = await _context.Empresa.FirstOrDefaultAsync(enterpriseBanco => enterpriseBanco.Id == schedulingCreateDto.EmpresaId);
//
//                 if (enterprise == null)
//                 {
//                     respost.Mensagem = "Enterprise not found";
//                     return respost;
//                 }
//
//                 var client = await _context.Cliente.FirstOrDefaultAsync(clientBanco => clientBanco.Id == schedulingCreateDto.ClienteId);
//
//                 if (client == null)
//                 {
//                     respost.Mensagem = "Client not found";
//                     return respost;
//                 }
//                 
//                 var professional = await _context.Profissional.FirstOrDefaultAsync(professionalBanco => professionalBanco.Id == schedulingCreateDto.ProfissionalId);
//
//                 if (client == null)
//                 {
//                     respost.Mensagem = "Professional not found";
//                     return respost;
//                 }
//
//                 var newScheduling = new Agendamento()
//                 {
//                     Data = schedulingCreateDto.Data,
//                     Observacao = schedulingCreateDto.Observacao,
//                     ServicoId = schedulingCreateDto.ServicoId,
//                     EmpresaId = schedulingCreateDto.EmpresaId,
//                     ClienteId = schedulingCreateDto.ClienteId,
//                     ProfissionalId = schedulingCreateDto.ProfissionalId
//                 };
//
//                 _context.Agendamento.Add(newScheduling);
//                 _context.SaveChanges();
//
//                 respost.Dados = newScheduling;
//
//                 respost.Mensagem = "Scheduling created successfull!";
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
//
//         public async Task<ResponseModel<Agendamento>> DeleteScheduling(int idScheduling)
//         {
//             ResponseModel<Agendamento> respost = new ResponseModel<Agendamento>();
//
//             try
//             {
//
//                 var scheduling = await _context.Agendamento.FirstOrDefaultAsync(schedulingBank => schedulingBank.Id == idScheduling);
//
//                 if (scheduling == null)
//                 {
//                     respost.Mensagem = "Scheduling not found";
//                     return respost;
//                 }
//
//                 _context.Remove(scheduling);
//                 _context.SaveChanges();
//
//                 respost.Dados = scheduling;
//                 respost.Mensagem = "Scheduling delete successfull!";
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
//
//         public async Task<ResponseModel<List<Agendamento>>> GetAllSchedulings(int EnterpriseId)
//         {
//             ResponseModel<List<Agendamento>> respost = new ResponseModel<List<Agendamento>>();
//
//             try
//             {
//                 var enterprise = await _context.Empresa.FirstOrDefaultAsync(a => a.Id == EnterpriseId);
//
//                 if (enterprise == null)
//                 {
//                     respost.Mensagem = "User not found";
//                     return respost;
//                 }
//
//                 var schedulings = await _context.Agendamento
//                     .Where(s => s.EmpresaId == EnterpriseId)
//                     .ToListAsync();
//
//                 respost.Dados = schedulings;
//                 respost.Mensagem = "Get schedulings successfull!";
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
