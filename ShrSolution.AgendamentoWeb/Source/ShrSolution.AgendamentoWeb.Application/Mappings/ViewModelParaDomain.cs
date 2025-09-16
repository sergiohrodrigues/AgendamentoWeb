using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.ViewModels;
using ShrSolution.AgendamentoWeb.Application.ViewModels.Empresa;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Empresa, EmpresaViewModel>().ReverseMap();

        CreateMap<AdicionarEmpresaViewModel, Empresa>();
    }
}