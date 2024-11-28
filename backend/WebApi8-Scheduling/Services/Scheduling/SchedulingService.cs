
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
        public async Task<ResponseModel<SchedulingModel>> CreateSheduling(SchedulingCreateDto scheduling)
        {
            ResponseModel<SchedulingModel> respost = new ResponseModel<SchedulingModel>();

            try
            {
                Console.WriteLine("teste");

                var clientId = await _context.Clients.FirstOrDefaultAsync(clientBanco => clientBanco.Id == scheduling.ClientId);

                if(clientId == null)
                {
                    respost.Mensagem = "Client not found";
                    return respost;
                }

                var serviceId = await _context.Services.FirstOrDefaultAsync(serviceBanco => serviceBanco.Id == scheduling.ServiceId);

                if (serviceId == null)
                {
                    respost.Mensagem = "Service not found";
                    return respost;
                }

                var newScheduling = new SchedulingModel()
                {
                    DateHour = scheduling.DateHour,
                    Observation = scheduling.Observation,
                    ClientId = scheduling.ClientId,
                    ServiceId = scheduling.ServiceId,
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
    }
}
