namespace ShrSolution.AgendamentoWeb.Application.Extensions;

public static class DateTimeExtensions
{
    public static bool EhDomingo(this DateTime dateTime)
        => dateTime.DayOfWeek == DayOfWeek.Sunday;

    public static bool EhHorarioDeTrabalho(this DateTime dateTime, int startHour = 8, int endHour = 18)
        => dateTime.Hour >= startHour && dateTime.Hour < endHour;
}