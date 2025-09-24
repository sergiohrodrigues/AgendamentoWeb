using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Cliente;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Application.Mappings;

public class ViewModelParaDomain : Profile
{
    public ViewModelParaDomain()
    {
        CreateMap<EmpresaViewModel, Empresa>();
        CreateMap<AdicionarEmpresaViewModel, Empresa>();
        CreateMap<AdicionarProfissionalViewModel, Profissional>();
        CreateMap<AdicionarClienteViewModel, Cliente>();
        CreateMap<EditarClienteViewModel, Cliente>();
    }
}