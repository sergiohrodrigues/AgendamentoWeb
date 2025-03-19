
using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Scheduling
{
    public class ServiceService : IServiceInterface
    {
        private readonly AppDbContext _context;
        public ServiceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ServiceModel>>> GetAllServices()
        {
            ResponseModel<List<ServiceModel>> respost = new ResponseModel<List<ServiceModel>>();

            try
            {
                respost.Dados = await _context.Services.ToListAsync();
                respost.Mensagem = "Get services successfull!";
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
