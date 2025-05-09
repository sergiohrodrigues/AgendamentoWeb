
using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.Scheduling;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Scheduling
{
    public class SchedulingService : ISchedulingInterface
    {
        private readonly AppDbContext _context;
        public SchedulingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<SchedulingModel>> CreateSheduling(SchedulingCreateDto schedulingCreateDto)
        {
            ResponseModel<SchedulingModel> respost = new ResponseModel<SchedulingModel>();

            try
            {
                var serviceId = await _context.Services.FirstOrDefaultAsync(serviceBanco => serviceBanco.Id == schedulingCreateDto.ServiceId);

                if (serviceId == null)
                {
                    respost.Mensagem = "Service not found";
                    return respost;
                }

                var enterprise = await _context.Enterprise.FirstOrDefaultAsync(enterpriseBanco => enterpriseBanco.Id == schedulingCreateDto.EnterpriseId);

                if (enterprise == null)
                {
                    respost.Mensagem = "Enterprise not found";
                    return respost;
                }

                var client = await _context.Clients.FirstOrDefaultAsync(clientBanco => clientBanco.Id == schedulingCreateDto.ClientId);

                if (client == null)
                {
                    respost.Mensagem = "Client not found";
                    return respost;
                }
                
                var professional = await _context.Professional.FirstOrDefaultAsync(professionalBanco => professionalBanco.Id == schedulingCreateDto.ProfessionalId);

                if (client == null)
                {
                    respost.Mensagem = "Professional not found";
                    return respost;
                }

                var newScheduling = new SchedulingModel()
                {
                    DateHour = schedulingCreateDto.DateHour,
                    Observation = schedulingCreateDto.Observation,
                    ServiceId = schedulingCreateDto.ServiceId,
                    EnterpriseId = schedulingCreateDto.EnterpriseId,
                    ClientId = schedulingCreateDto.ClientId,
                    ProfessionalId = schedulingCreateDto.ProfessionalId
                };

                _context.Scheduling.Add(newScheduling);
                _context.SaveChanges();

                respost.Dados = newScheduling;

                respost.Mensagem = "Scheduling created successfull!";
                return respost;

            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<SchedulingModel>> DeleteScheduling(int idScheduling)
        {
            ResponseModel<SchedulingModel> respost = new ResponseModel<SchedulingModel>();

            try
            {

                var scheduling = await _context.Scheduling.FirstOrDefaultAsync(schedulingBank => schedulingBank.Id == idScheduling);

                Console.WriteLine(scheduling);

                if (scheduling == null)
                {
                    respost.Mensagem = "Scheduling not found";
                    return respost;
                }

                _context.Remove(scheduling);
                _context.SaveChanges();

                respost.Dados = scheduling;
                respost.Mensagem = "Scheduling delete successfull!";
                return respost;

            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<List<SchedulingModel>>> GetAllSchedulings(int EnterpriseId)
        {
            ResponseModel<List<SchedulingModel>> respost = new ResponseModel<List<SchedulingModel>>();

            try
            {
                var enterprise = await _context.Enterprise.FirstOrDefaultAsync(a => a.Id == EnterpriseId);

                if (enterprise == null)
                {
                    respost.Mensagem = "User not found";
                    return respost;
                }

                var schedulings = await _context.Scheduling
                    .Where(s => s.EnterpriseId == EnterpriseId)
                    .ToListAsync();

                respost.Dados = schedulings;
                respost.Mensagem = "Get schedulings successfull!";
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
