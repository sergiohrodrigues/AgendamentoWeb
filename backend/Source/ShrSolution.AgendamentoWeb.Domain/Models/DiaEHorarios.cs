namespace ShrSolution.AgendamentoWeb.Domain.Models
{
    public class DiaEHorarios
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public string DayOfWeekName { get; set; }
        public int DayId { get; set; }
        public List<string> Horarios { get; set; }

        public DiaEHorarios(DateTime day)
        {
            Day = day.Date.Day;
            Month = day.Date.Month;
            DayOfWeekName = BuscarDiaDaSemanaEmPortugues(day);
            DayId = (int)day.DayOfWeek;
        }

        private string BuscarDiaDaSemanaEmPortugues(DateTime date)
        {
            var dayOfWeek = date.ToString("dddd", new System.Globalization.CultureInfo("pt-BR"));
            return char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
        }
    }
}
