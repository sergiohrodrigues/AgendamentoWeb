namespace WebApi8_Scheduling.Dto.AgendaBase
{
    public class AgendaBaseCreateDto
    {
        public int ProfissionalId { get; set; }

        public int DiaSemana { get; set; }

        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }

        public int TurnoTrabalhoId { get; set; }
    }
}
