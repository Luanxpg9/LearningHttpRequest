namespace LearningHttpRequest.Controllers.Adapter
{
    public class CityAdapter : ICityAdapter
    {
        public CityClimate ConvertToCityClimate(JsonContent response)
        {
            throw new NotImplementedException();
           /* var cityClimate = new CityClimate
            {
                CityName = response.Value("name"),
                CityCode = response.GetString("code"),
                Temperature = response.GetString("temperature"),
                Latitude = response.GetString("latt"),
                Longitude = response.GetString("long")
            };*/
        }
    }
}
