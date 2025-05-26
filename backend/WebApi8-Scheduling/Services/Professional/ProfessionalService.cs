using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Dto.Professional;
using WebApi8_Scheduling.Dto.Service;
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

        public async Task<ResponseModel<ProfissionalModel>> CreateProfessional(ProfessionalCreateDto pProfessional)
        {
            ResponseModel<ProfissionalModel> respost = new ResponseModel<ProfissionalModel>();

            try
            {
                var enterprise = _context.Empresa.FirstOrDefault(p => p.Id == pProfessional.EnterpriseId);

                if (enterprise == null)
                {
                    respost.Mensagem = "Enterprise not found!";
                    return respost;
                }

                var newProfessinoal = new ProfissionalModel
                {
                    Nome = pProfessional.Nome,
                    Email = pProfessional.Email,
                    Telefone = pProfessional.Telefone,
                    EmpresaId = pProfessional.EnterpriseId
                };

                _context.Profissional.Add(newProfessinoal);
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

        public async Task<ResponseModel<List<ProfissionalModel>>> GetAllProfessional(int enterpriseId)
        {
            ResponseModel<List<ProfissionalModel>> respost = new ResponseModel<List<ProfissionalModel>>();

            try
            {
                var enterprise = _context.Empresa.FirstOrDefault(p => p.Id == enterpriseId);

                if (enterprise == null)
                {
                    respost.Mensagem = "Enterprise not found!";
                    return respost;
                }

                var professionals = await _context.Profissional
                    .Where(s => s.EmpresaId == enterpriseId)
                    .Where(p => p.Ativo == true)
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

        public async Task<ResponseModel<List<ProfissionalServico>>> BuscarServicosProfissional(int profissionalId)
        {
            ResponseModel<List<ProfissionalServico>> resposta = new ResponseModel<List<ProfissionalServico>>();

            try
            {
                var xServicos = await _context.ProfissionalServico
                    .Include(ps => ps.Servico)
                    .Where(ps => ps.ProfissionalId == profissionalId)
                    .ToListAsync();

                if (xServicos == null || xServicos.Count == 0)
                {
                    resposta.Mensagem = "Serviços não encontrados!";
                    return resposta;
                }

                resposta.Dados = xServicos;
                resposta.Mensagem = "Serviços encontrados com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<string>> RemoverDiaDaAgendaDoProfissional(int profissionalId, RemoverDiaProfissionalDto pRemoverDiaProfissional)
        {
            ResponseModel<string> resposta = new ResponseModel<string>();

            try
            {
                var diaASerRemovido = new AgendaIndisponivelModel
                {
                    ProfissionalId = profissionalId,
                    Data = pRemoverDiaProfissional.Data,
                    Motivo = pRemoverDiaProfissional.Motivo
                };

                _context.AgendaIndisponivel.Add(diaASerRemovido);
                _context.SaveChanges();

                resposta.Dados = diaASerRemovido.Data.ToString();
                resposta.Mensagem = "Dia removido da agenda com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}