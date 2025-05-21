namespace WebApi8_Scheduling.Dto.AgendaBase
{
    public class AgendaBaseEditDto
    {

        public int DiaSemana { get; set; }

        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }

        public int TurnoTrabalhoId { get; set; }
    }
}
