using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Agendamento;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Servico;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Application.Mappings;

public class ViewModelParaDomain : Profile
{
    public ViewModelParaDomain()
    {
        CreateMap<AdicionarEmpresaViewModel, Empresa>();
        CreateMap<AdicionarProfissionalViewModel, Profissional>();
        CreateMap<AdicionarClienteViewModel, Cliente>();
        CreateMap<EditarClienteViewModel, Cliente>();
        CreateMap<AdicionarServicoViewModel, Servico>();
        CreateMap<AdicionarAgendamentoViewModel, Agendamento>();
    }
}