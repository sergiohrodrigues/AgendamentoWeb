using System.Text.Json.Serialization;

namespace WebApi8_Scheduling.Models;

public class ProfissionalServico
{
    public int ProfissionalId { get; set; }
    public ProfissionalModel Profissional { get; set; }
    public int ServicoId { get; set; }
    public ServicoModel Servico { get; set; }
}