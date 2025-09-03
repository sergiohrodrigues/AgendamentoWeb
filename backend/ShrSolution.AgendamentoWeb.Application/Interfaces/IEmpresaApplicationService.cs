using ShrSolution.AgendamentoWeb.Application.ViewModels;

namespace ShrSolution.AgendamentoWeb.Application.Interfaces;

public interface IEmpresaApplicationService
{
    Task<EmpresaViewModel?> ObterEmpresaPorId(int pEmpresaId);
}