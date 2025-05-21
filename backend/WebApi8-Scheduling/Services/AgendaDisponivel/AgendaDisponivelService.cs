using Azure;
using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.AgendaBase;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.AgendaBase
{
    public class AgendaDisponivelService : IAgendaDisponivelService
    {
        private readonly AppDbContext _context;

        public AgendaDisponivelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AgendaDisponivel>>> AddDefaultSchedules(int pProfessionalId)
        {
            ResponseModel<List<AgendaDisponivel>> respost = new ResponseModel<List<AgendaDisponivel>>();

            try
            {
                var professional = await _context.Professional.FirstOrDefaultAsync(a => a.Id == pProfessionalId);

                if (professional == null)
                {
                    respost.Mensagem = "Professional not found!";
                    return respost;
                }

                var agendas = new List<AgendaDisponivel>();

                for (int dia = 1; dia <= 6; dia++)
                {
                    var hoje = DateTime.UtcNow.Date;
                    var dataAgenda = hoje.AddDays((7 + dia - (int)hoje.DayOfWeek) % 7);
                    
                    // Turno manhã
                    agendas.Add(new AgendaDisponivel
                    {
                        ProfissionalId = pProfessionalId,
                        DiaDaSemana = dia,
                        HorarioInicio = dataAgenda.AddHours(8), // 08:00 UTC
                        HorarioFim = dataAgenda.AddHours(12),  // 12:00 UTC
                        TurnoTrabalhoId = 1
                    });

                    // Turno tarde
                    agendas.Add(new AgendaDisponivel
                    {
                        ProfissionalId = pProfessionalId,
                        DiaDaSemana = dia,
                        HorarioInicio = dataAgenda.AddHours(13), // 13:00 UTC
                        HorarioFim = dataAgenda.AddHours(18),  // 18:00 UTC
                        TurnoTrabalhoId = 2
                    });
                }

                _context.AgendaDisponivel.AddRange(agendas);
                await _context.SaveChangesAsync();

                respost.Dados = agendas;
                respost.Mensagem = "new default agenda created successfully!";

                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<AgendaDisponivel>> CreateAgendaBase(AgendaBaseCreateDto pAgendaBaseDto)
        {
            ResponseModel<AgendaDisponivel> respost = new ResponseModel<AgendaDisponivel>();

            try
            {
                var professional = await _context.Professional.FirstOrDefaultAsync(a => a.Id == pAgendaBaseDto.ProfissionalId);

                if (professional == null)
                {
                    respost.Mensagem = "Professional not found!";
                    return respost;
                }

                var newAgendaBase= new AgendaDisponivel()
                {
                    ProfissionalId = pAgendaBaseDto.ProfissionalId,
                    DiaDaSemana = pAgendaBaseDto.DiaSemana,
                    HorarioInicio = pAgendaBaseDto.HorarioInicio,
                    HorarioFim = pAgendaBaseDto.HorarioFim,
                    TurnoTrabalhoId = pAgendaBaseDto.TurnoTrabalhoId,
                };

                _context.AgendaDisponivel.Add(newAgendaBase);
                _context.SaveChanges();

                respost.Dados = newAgendaBase;
                respost.Mensagem = "new agenda base created successfully!";

                return respost;
            }
            catch (Exception ex)
            {
                respost.Mensagem = ex.Message;
                respost.Status = false;
                return respost;
            }
        }

        public async Task<ResponseModel<AgendaDisponivel>> EditAgendaBase(int pProfessionalId, AgendaBaseEditDto pAgendaBaseEditDto)
        {
            ResponseModel<AgendaDisponivel> respost = new ResponseModel<AgendaDisponivel>();

            try
            {
                var xProfessional = await _context.Professional.FirstOrDefaultAsync(a => a.Id == pProfessionalId);

                if (xProfessional == null)
                {
                    respost.Mensagem = "Professional not found!";
                    return respost;
                }

                var xAgendaBase = await _context.AgendaDisponivel.FirstOrDefaultAsync(p => p.ProfissionalId == pProfessionalId && p.DiaDaSemana == pAgendaBaseEditDto.DiaSemana);

                if (xAgendaBase == null)
                {
                    respost.Mensagem = "Agenda base not found!";
                    return respost;
                }

                xAgendaBase.DiaDaSemana = pAgendaBaseEditDto.DiaSemana;
                xAgendaBase.HorarioInicio = pAgendaBaseEditDto.HorarioInicio;
                xAgendaBase.HorarioFim = pAgendaBaseEditDto.HorarioFim;
                xAgendaBase.TurnoTrabalhoId = pAgendaBaseEditDto.TurnoTrabalhoId;

                _context.AgendaDisponivel.Update(xAgendaBase);
                _context.SaveChanges();

                respost.Dados = xAgendaBase;
                respost.Mensagem = "Agenda base edited successfully!";

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
