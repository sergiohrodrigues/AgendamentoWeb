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
                var xSchdules =  _context.AgendaDisponivel
                    .Where(p => p.ProfissionalId == pProfessionalId && p.DiaDaSemana == pDayWeek)
                    .Select(p => new AgendaDisponivel()
                    {
                        HorarioInicio = p.HorarioInicio,
                        HorarioFim = p.HorarioFim
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
                    var inicio = item.HorarioInicio;
                    var fim = item.HorarioFim;

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

        public async Task<ResponseModel<List<DateTime>>> BuscarHorariosDisponiveis(int profissionalId, DateTime dataInicial, DateTime dataFinal)
        {
            ResponseModel<List<DateTime>> respost = new ResponseModel<List<DateTime>>();

            try
            {
                var disponiblidades = _context.AgendaDisponivel
                    .Where(d => d.ProfissionalId == profissionalId)
                    .ToList();

                var indisponibilidades = _context.AgendaIndisponivel
                    .Where(i => i.ProfissionalId == profissionalId)
                    .Select(i => i.Data).ToHashSet();

                var agendamentos = _context.Scheduling
                    .Where(a => a.ProfessionalId == profissionalId && a.DateHour >= dataInicial &&
                                a.DateHour <= dataFinal)
                    .Select(a => a.DateHour)
                    .ToHashSet();

                var horariosDisponiveis = new List<DateTime>();

                for (var data = dataInicial.Date; data <= dataFinal.Date; data = data.AddDays(1))
                {
                    if (indisponibilidades.Contains(data)) continue;

                    var diaSemana = data.Day;

                    foreach (var disp in disponiblidades.Where(d => d.DiaDaSemana == diaSemana))
                    {
                        for (var hora = disp.HorarioInicio; hora < disp.HorarioFim; hora += TimeSpan.FromMinutes(30))
                        {
                            // var horario = data + hora;
                            // if (!agendamentos.Contains(horario))
                            //     horariosDisponiveis.Add(horario);
                        }
                    }
                }

                respost.Dados = horariosDisponiveis;
                respost.Mensagem = "Horarios disponiveis do profissional obtidos com sucesso!";
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