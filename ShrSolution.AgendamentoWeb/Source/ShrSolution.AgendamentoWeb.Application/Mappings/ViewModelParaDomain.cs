using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmpresaViewModel, Empresa>();
        CreateMap<AdicionarEmpresaViewModel, Empresa>();
        CreateMap<AdicionarProfissionalViewModel, Profissional>();
    }
}