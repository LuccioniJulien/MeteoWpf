namespace Meteo.Helper.Dependency
{
    public interface ITimeProvider
    {
        string GetHour(long timeStamp, string olsonZone);
        string GetDay(long timeStamp, string olsonZone);
    }
}
