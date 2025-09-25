namespace ShrSolution.AgendamentoWeb.Application.ViewModels.Profissional;

public class ProfissionalViewModel
{
    public string Nome { get; set; }
    public string? Email { get; set; }
    public string Telefone { get; set; }
    public bool Ativo { get; set; } = true;
    public int? EmpresaId { get; set; }
}