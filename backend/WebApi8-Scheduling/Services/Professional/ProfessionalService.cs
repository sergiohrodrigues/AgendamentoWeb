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
    }
}
