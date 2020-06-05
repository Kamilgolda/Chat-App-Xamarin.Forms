using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace zadApi.Models
{
    public class Rows
    {
        public string country { get; set; }
        public string country_abbreviation { get; set; }
        public string total_cases { get; set; }
        public string new_cases { get; set; }
        public string total_deaths { get; set; }
        public string new_deaths { get; set; }
        public string total_recovered { get; set; }
        public string active_cases { get; set; }
        public string serious_critical { get; set; }
        public string cases_per_mill_pop { get; set; }
        public string flag { get; set; }

    }
}