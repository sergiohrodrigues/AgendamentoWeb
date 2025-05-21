namespace WebApi8_Scheduling.Models
{
    public class WorkShiftModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<AgendaDisponivel>? Times { get; set; }
    }
}
