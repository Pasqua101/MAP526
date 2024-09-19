using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Digimon
{
    public class DigimonModel
    {
        // after you define the digimon class, you need to map your properties
        // to the individual properties in the API response

        // The value provided to JsonProperty is the name of the property in the API 
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("img")]
        public string Image { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        public DigimonModel()
        {
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Level: {this.Level}";
        }
    }
}
