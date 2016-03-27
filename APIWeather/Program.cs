using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using WeatherAPP;
using WeatherReporter;

namespace WeatherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Zipcode to see Weather Conditions");
            string userInput = Console.ReadLine();

            //Allow a user to put in a zip

            //var userInput = "72120";
            //var userInput = "Little Rock, AR";

            var mgr = new WeatherManger();

            var hurricanes = mgr.AllHurricanes();
            ;
            if (hurricanes != null)
            {
                for (int i = 0; i < hurricanes.Count; i++)
                {
                    Console.WriteLine(hurricanes[i].currenthurricane.storminfo.stormName);
                }
            }
            else
            {
                Console.WriteLine("No Hurricanes");
            }

            var conditionsByZip = mgr.ConditionsZip(userInput);

            if (conditionsByZip != null)
            {
                var forecast10 = mgr.Forecast10Days(userInput);
                //Conditions
                Console.WriteLine($"Overall Weather: {conditionsByZip[0].current_observation.weather}");
                Console.WriteLine($"Temperature: {conditionsByZip[0].current_observation.temperature_string}");
                Console.WriteLine($"Humidity: {conditionsByZip[0].current_observation.relative_humidity}");
                Console.WriteLine($"Feels Like: {conditionsByZip[0].current_observation.feelslike_string}");
                Console.WriteLine($"Precipitation: {conditionsByZip[0].current_observation.precip_today_string}");
                Console.WriteLine($"Wind: {conditionsByZip[0].current_observation.wind_string}");
                Console.WriteLine($"WindChill: {conditionsByZip[0].current_observation.windchill_string}");
                Console.WriteLine("10 DAY FORECAST////////////////");
                //forecast10
                for (int i = 0; i < forecast10[0].forecast.txt_forecast.forecastday.Count; i++)
                {

                    Console.WriteLine($"{forecast10[0].forecast.txt_forecast.forecastday[i].title}");
                    Console.WriteLine($"{forecast10[0].forecast.txt_forecast.forecastday[i].fcttext}");
                }
            }
            else
            {
                Console.WriteLine("Retype zipcode please");
            }

            Console.ReadLine();
        }
    }
}
