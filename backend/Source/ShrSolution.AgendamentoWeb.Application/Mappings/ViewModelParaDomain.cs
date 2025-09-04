using AutoMapper;
using ShrSolution.AgendamentoWeb.Application.ViewModels;
using ShrSolution.AgendamentoWeb.Domain.Models;

namespace ShrSolution.AgendamentoWeb.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
    }
}