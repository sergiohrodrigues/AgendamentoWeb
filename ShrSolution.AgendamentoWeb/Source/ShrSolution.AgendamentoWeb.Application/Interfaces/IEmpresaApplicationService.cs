using ShrSolution.AgendamentoWeb.Application.ViewModels;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IEmpresaApplicationService
{
    Task<EmpresaViewModel?> ObterEmpresaPorId(int pEmpresaId);
    Task<AdicionarEmpresaViewModel> Adicionar(AdicionarEmpresaViewModel pEmpresa);
}