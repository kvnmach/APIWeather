using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using WeatherApp;
using WeatherReporter;

namespace WeatherAPP
{

    public class WeatherManger
    {
        public List<Conditions> ConditionsZip(string userInput)
        {
            var isZip = FigureOutLookupType(userInput);

            ILookup lookupWeather = new WeatherLookUp();

            if (isZip == true)
            {
                return lookupWeather.GetByZip(userInput);
            }

            return null;
        }

        public List<Hurricanes> AllHurricanes()
        {
            ILookup lookupHurricanes = new WeatherLookUp();

            return lookupHurricanes.GetHurricanes();
        }

        public List<Forecast10day> Forecast10Days(string userInput)
        {
            ILookup lookupWeather = new WeatherLookUp();

            return lookupWeather.GetByZipForecast10Days(userInput);
        }

        private bool FigureOutLookupType(string userInput)
        {
            //do regex check for zip here.
            Regex regex = new Regex(@"^\d{5}(?:[-\s]\d{4})?$", RegexOptions.IgnoreCase);

            MatchCollection zipcodeMatch = regex.Matches(userInput);

            if (zipcodeMatch.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}

