using Azure;
using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.AgendaBase;
using WebApi8_Scheduling.Models;

namespace WebApi8_Scheduling.Services.AgendaBase
{
    public class AgendaBaseService : IAgendaBaseService
    {
        private readonly AppDbContext _context;

        public AgendaBaseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AgendaBaseModel>>> AddDefaultSchedules(int pProfessionalId)
        {
            ResponseModel<List<AgendaBaseModel>> respost = new ResponseModel<List<AgendaBaseModel>>();

            try
            {
                var professional = await _context.Professional.FirstOrDefaultAsync(a => a.Id == pProfessionalId);

                if (professional == null)
                {
                    respost.Mensagem = "Professional not found!";
                    return respost;
                }

                var agendas = new List<AgendaBaseModel>();

                for (int dia = 1; dia <= 6; dia++)
                {
                    // Turno manhã
                    agendas.Add(new AgendaBaseModel
                    {
                        ProfessionalId = pProfessionalId,
                        DayWeek = dia,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(12, 0, 0)
                    });

                    // Turno tarde
                    agendas.Add(new AgendaBaseModel
                    {
                        ProfessionalId = pProfessionalId,
                        DayWeek = dia,
                        StartTime = new TimeSpan(13, 0, 0),
                        EndTime = new TimeSpan(18, 0, 0)
                    });
                }

                _context.AgendaBase.AddRange(agendas);
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

        public async Task<ResponseModel<AgendaBaseModel>> CreateAgendaBase(AgendaBaseCreateDto pAgendaBaseDto)
        {
            ResponseModel<AgendaBaseModel> respost = new ResponseModel<AgendaBaseModel>();

            try
            {
                var professional = await _context.Professional.FirstOrDefaultAsync(a => a.Id == pAgendaBaseDto.ProfessionalId);

                if (professional == null)
                {
                    respost.Mensagem = "Professional not found!";
                    return respost;
                }

                var newAgendaBase= new AgendaBaseModel()
                {
                    ProfessionalId = pAgendaBaseDto.ProfessionalId,
                    DayWeek = pAgendaBaseDto.DayWeek,
                    StartTime = pAgendaBaseDto.StartTime,
                    EndTime = pAgendaBaseDto.EndTime,
                };

                _context.AgendaBase.Add(newAgendaBase);
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

        public async Task<ResponseModel<AgendaBaseModel>> EditAgendaBase(int pProfessionalId, AgendaBaseEditDto pAgendaBaseEditDto)
        {
            ResponseModel<AgendaBaseModel> respost = new ResponseModel<AgendaBaseModel>();

            try
            {
                var xProfessional = await _context.Professional.FirstOrDefaultAsync(a => a.Id == pProfessionalId);

                if (xProfessional == null)
                {
                    respost.Mensagem = "Professional not found!";
                    return respost;
                }

                var xAgendaBase = await _context.AgendaBase.FirstOrDefaultAsync(p => p.ProfessionalId == pProfessionalId && p.DayWeek == pAgendaBaseEditDto.DayWeek);

                if (xAgendaBase == null)
                {
                    respost.Mensagem = "Agenda base not found!";
                    return respost;
                }

                xAgendaBase.DayWeek = pAgendaBaseEditDto.DayWeek;
                xAgendaBase.StartTime = pAgendaBaseEditDto.StartTime;
                xAgendaBase.EndTime = pAgendaBaseEditDto.EndTime;

                _context.AgendaBase.Update(xAgendaBase);
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
