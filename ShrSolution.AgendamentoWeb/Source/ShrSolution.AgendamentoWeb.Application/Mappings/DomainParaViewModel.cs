using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Agendamento;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Servico;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Application.Mappings;

public class DomainParaViewModel : Profile
{
    public DomainParaViewModel()
    {
        CreateMap<Cliente, ClienteViewModel>();
        CreateMap<Empresa, EmpresaViewModel>();
        CreateMap<Profissional, ProfissionalViewModel>();
        CreateMap<Servico, ServicoViewModel>();
        CreateMap<Agendamento, AgendamentoViewModel>();
    }
}