using System;

namespace Serialize_response_actionfilter
{
    [Serializable]
    public class WeatherForecast
    {
        public WeatherStation WeatherStationDetail { get; set; }

        public DateTime Date { get; set; }

        public Temperature Temperature { get; set; }

        public string Summary { get; set; }
    }

    public class WeatherStation
    {
        public string WeatherStationCode { get; set; }
        public string WeatherStationName { get; set; }
    }
    public class Temperature
    {
        public int Celsius { get; set; }

        private int farenheit = 0;
        public int Farenheit
        {
            get { return 32 + (int)(Celsius / 0.5556); }
            set { farenheit = value; }
        }
    }
}
