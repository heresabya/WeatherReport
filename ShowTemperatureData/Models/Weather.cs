using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowTemperatureData.Models
{
    public class Weather
    {
        private string temperature;
        private string humidity;

        public string Temperature { get => temperature; set => temperature = value; }
        public string Humidity { get => humidity; set => humidity = value; }
    }
}