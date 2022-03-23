namespace LearningHttpRequest.Controllers.Adapter
{
    public interface ICityAdapter
    {
        public CityClimate ConvertToCityClimate(JsonContent response);
    }
}
