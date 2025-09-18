using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Models;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;

namespace ShrSolution.AgendamentoWeb.Domain.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalRepository _profissionalRepository;
        public ProfissionalService(IProfissionalRepository pProfissionalRepository)
        {
            _profissionalRepository = pProfissionalRepository;
        }

        public async Task<Profissional?> ObterPorId(int pProfissionalId)
        {
            var xProfissional = await _profissionalRepository.ObterPorId(pProfissionalId);

            return xProfissional;
        }

        public void Adicionar (Profissional pProfissional)
        {
            _profissionalRepository.Adicionar(pProfissional);
        }
        //
        // public async Task<ResponseModel<List<Profissional>>> GetAllProfessional(int enterpriseId)
        // {
        //     ResponseModel<List<Profissional>> respost = new ResponseModel<List<Profissional>>();
        //
        //     try
        //     {
        //         // var enterprise = _context.Empresa.FirstOrDefault(p => p.Id == enterpriseId);
        //         //
        //         // if (enterprise == null)
        //         // {
        //         //     respost.Mensagem = "Enterprise not found!";
        //         //     return respost;
        //         // }
        //
        //         // var professionals = await _context.Profissional
        //         //     .Where(s => s.EmpresaId == enterpriseId)
        //         //     .Where(p => p.Ativo == true)
        //         //     .ToListAsync();
        //         //
        //         // respost.Dados = professionals;
        //         respost.Mensagem = "professionals got successfully!";
        //         return respost;
        //     }
        //     catch (Exception ex)
        //     {
        //         respost.Mensagem = ex.Message;
        //         respost.Status = false;
        //         return respost;
        //     }
        // }
        //
        // public async Task<ResponseModel<List<ProfissionalServico>>> BuscarServicosProfissional(int profissionalId)
        // {
        //     ResponseModel<List<ProfissionalServico>> resposta = new ResponseModel<List<ProfissionalServico>>();
        //
        //     try
        //     {
        //         var xServicos = await _profissionalRepository.ProfissionalServico
        //             .Include(ps => ps.Servico)
        //             .Where(ps => ps.ProfissionalId == profissionalId)
        //             .ToListAsync();
        //
        //         if (xServicos == null || xServicos.Count == 0)
        //         {
        //             resposta.Mensagem = "Serviços não encontrados!";
        //             return resposta;
        //         }
        //
        //         resposta.Dados = xServicos;
        //         resposta.Mensagem = "Serviços encontrados com sucesso!";
        //         return resposta;
        //     }
        //     catch (Exception ex)
        //     {
        //         resposta.Mensagem = ex.Message;
        //         resposta.Status = false;
        //         return resposta;
        //     }
        // }
        //
        // public async Task<ResponseModel<string>> RemoverDiaDaAgendaDoProfissional(int profissionalId, RemoverDiaProfissionalDto pRemoverDiaProfissional)
        // {
        //     ResponseModel<string> resposta = new ResponseModel<string>();
        //
        //     try
        //     {
        //         var diaASerRemovido = new AgendaIndisponivel
        //         {
        //             ProfissionalId = profissionalId,
        //             Data = pRemoverDiaProfissional.Data,
        //             Motivo = pRemoverDiaProfissional.Motivo
        //         };
        //
        //         _profissionalRepository.AgendaIndisponivel.Add(diaASerRemovido);
        //         _profissionalRepository.SaveChanges();
        //
        //         resposta.Dados = diaASerRemovido.Data.ToString();
        //         resposta.Mensagem = "Dia removido da agenda com sucesso!";
        //         return resposta;
        //     }
        //     catch (Exception ex)
        //     {
        //         resposta.Mensagem = ex.Message;
        //         resposta.Status = false;
        //         return resposta;
        //     }
        // }
    }
}