
using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.Service;
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

        public async Task<ResponseModel<ServiceModel>> CreateService(ServiceCreateDto pService)
        {
            ResponseModel<ServiceModel> respost = new ResponseModel<ServiceModel>();

            try
            {
                var xEnterprise = await _context.Enterprise.FirstOrDefaultAsync(p => p.Id == pService.EnterpriseId);

                if (xEnterprise == null)
                {
                    respost.Mensagem = "Enteprise not found";
                    return respost;
                }
                
                var xProfessional = await _context.Professional.FirstOrDefaultAsync(p => p.Id == pService.ProfessionalId);

                if (xProfessional == null)
                {
                    respost.Mensagem = "Professional not found";
                    return respost;
                }

                var xNewService = new ServiceModel
                {
                    Name = pService.Name,
                    Description = pService.Description,
                    Price = pService.Price,
                    EnterpriseId = pService.EnterpriseId,
                    ProfessionalId = pService.ProfessionalId,
                };

                _context.Services.Add(xNewService);
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
