namespace WebApi8_Scheduling.Models;

public class AgendaIndisponivelModel
{
    public int Id { get; set; }
    public int ProfissionalId { get; set; }
    public DateTime Data { get; set; }
    public string Motivo { get; set; }
}