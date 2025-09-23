using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Application.Mappings;

public class DomainParaViewModel : Profile
{
    public DomainParaViewModel()
    {
        CreateMap<Cliente, ClienteViewModel>();
    }
}