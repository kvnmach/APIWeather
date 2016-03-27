using System;
using System.Collections.Generic;
using RestSharp;
using WeatherReporter;

namespace WeatherApp
{
    public interface ILookup
    {
        List<Conditions> GetByZip(string zip);
        List<Forecast10day> GetByZipForecast10Days(string zip);
        List<Hurricanes> GetHurricanes();
    }

    public class WeatherLookUp : ILookup
    {
        public List<Conditions> GetByZip(string zip)
        {
            var client = new RestClient("http://api.wunderground.com/api/8c2eece0e7bd8db8/conditions/q/");

            var request = new RestRequest($"{zip}.json", Method.GET);

            var response = client.Execute<List<Conditions>>(request);
            return response.Data;
        }

        public List<Forecast10day> GetByZipForecast10Days(string zip)
        {
            var client = new RestClient("http://api.wunderground.com/api/8c2eece0e7bd8db8/forecast10day/q/");

            var request = new RestRequest($"{zip}.json", Method.GET);

            var response = client.Execute<List<Forecast10day>>(request);
            return response.Data;
        }

        public List<Hurricanes> GetHurricanes()
        {
            var client = new RestClient("http://api.wunderground.com/api/8c2eece0e7bd8db8/currenthurricane/");

            var request = new RestRequest($"view.json", Method.GET);

            var response = client.Execute<List<Hurricanes>>(request);
            return response.Data;
        }
    }
}