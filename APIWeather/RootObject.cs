using System.Collections.Generic;

namespace WeatherReporter
{
    //condition stuff
    public class DisplayLocation
    {
        public string city { get; set; }
        public string state_name { get; set; }
        public string zip { get; set; }
    }

    public class CurrentObservation
    {
        public DisplayLocation display_location { get; set; }
        public string weather { get; set; }
        public string temperature_string { get; set; }
        public string relative_humidity { get; set; }
        public string wind_string { get; set; }
        public string windchill_string { get; set; }
        public string feelslike_string { get; set; }
        public string precip_today_string { get; set; }
    }

    public class Conditions
    {
        public virtual CurrentObservation current_observation { get; set; }
    }

    //forecast stuff
    public class Forecastday
    {
        public string title { get; set; }
        public string fcttext { get; set; }
    }

    public class TxtForecast
    {
        public virtual List<Forecastday> forecastday { get; set; }
    }

    public class Forecast
    {
        public virtual TxtForecast txt_forecast { get; set; }
    }

    public class Forecast10day
    {
        public virtual Forecast forecast { get; set; }
    }

    //hurricane stuff

    public class StormInfo
    {
        public string stormName { get; set; }
    }

    public class Currenthurricane
    {
        public virtual StormInfo storminfo { get; set; }
    }

    public class Hurricanes
    {
        public virtual Currenthurricane currenthurricane { get; set; }
    }

}