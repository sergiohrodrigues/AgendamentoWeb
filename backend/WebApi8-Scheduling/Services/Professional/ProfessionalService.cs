using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.Professional;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.Professional
{
    public class ProfessionalService : IProfessionalService
    {
        private readonly AppDbContext _context;
        public ProfessionalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ProfessionalModel>> CreateProfessional(ProfessionalCreateDto pProfessional)
        {
            ResponseModel<ProfessionalModel> respost = new ResponseModel<ProfessionalModel>();

            try
            {
                var enterprise = _context.Enterprise.FirstOrDefault(p => p.Id == pProfessional.EnterpriseId);

                if (enterprise == null)
                {
                    respost.Mensagem = "Enterprise not found!";
                    return respost;
                }

                var newProfessinoal = new ProfessionalModel
                {
                    Nome = pProfessional.Nome,
                    Email = pProfessional.Email,
                    Telefone = pProfessional.Telefone,
                    EnterpriseId = pProfessional.EnterpriseId
                };

                _context.Professional.Add(newProfessinoal);
                _context.SaveChanges();

                respost.Dados = newProfessinoal;

                respost.Mensagem = "Professional create successfull!";
                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<List<ProfessionalModel>>> GetAllProfessional(int enterpriseId)
        {
            ResponseModel<List<ProfessionalModel>> respost = new ResponseModel<List<ProfessionalModel>>();

            try
            {
                var enterprise = _context.Enterprise.FirstOrDefault(p => p.Id == enterpriseId);

                if (enterprise == null)
                {
                    respost.Mensagem = "Enterprise not found!";
                    return respost;
                }

                var professionals = await _context.Professional
                    .Where(s => s.EnterpriseId == enterpriseId)
                    .ToListAsync();

                respost.Dados = professionals;
                respost.Mensagem = "professionals got successfully!";
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