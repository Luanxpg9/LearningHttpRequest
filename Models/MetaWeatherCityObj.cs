namespace LearningHttpRequest.Models
{
    public class MetaWeatherCityObj
    {
        public DayForecast[] Consolidated_weather { get; set; }
        public DateTime Time { get; set; }
        public DateTime Sun_rise { get; set; }
        public DateTime Sun_set { get; set; }
        public string Title { get; set; }
        public string Latt_long { get; set; }
    }
}
