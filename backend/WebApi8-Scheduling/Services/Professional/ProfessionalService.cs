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

        public async Task<ResponseModel<List<string>>> GetSchedulesProfessional(int pDayWeek, int pProfessionalId)
        {
            ResponseModel<List<string>> respost = new ResponseModel<List<string>>();

            try
            {
                var xSchdules =  _context.AgendaBase
                    .Where(p => p.ProfessionalId == pProfessionalId && p.DayWeek == pDayWeek)
                    .Select(p => new AgendaBaseModel()
                    {
                        StartTime = p.StartTime,
                        EndTime = p.EndTime
                    }).ToList();

                if (xSchdules.Count == 0)
                {
                    respost.Mensagem = "Day week our professional not found!";
                    return respost;
                }
                
                var xResultado = new List<string>();
                var intervalo = TimeSpan.FromHours(1);
                
                foreach (var item in xSchdules)
                {
                    var inicio = item.StartTime;
                    var fim = item.EndTime;

                    var totalHoras = (int)(fim - inicio).TotalHours;
    
                    for (int i = 0; i < totalHoras; i++)
                    {
                        var horaAtual = inicio.Add(TimeSpan.FromHours(i));
                        xResultado.Add(horaAtual.ToString(@"hh\:mm"));
                    }
                }

                respost.Dados = xResultado;
                respost.Mensagem = "Schedules professional got successfully!";
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