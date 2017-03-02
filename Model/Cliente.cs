using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace FormsTestApp
{
	public class Cliente : ObservableObject
    {

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Account")]
        public string Account { get; set; }

        [JsonProperty("Contact")]
        public string Contact { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Mobile")]
        public string Mobile { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitud")]
        public double Longitud { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }
    }
	
}
