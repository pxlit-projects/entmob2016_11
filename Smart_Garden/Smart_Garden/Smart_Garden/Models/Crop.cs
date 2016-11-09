using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Models
{
    public class Crop
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("temperature")]
        public double Temperature { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("light")]
        public double Light { get; set; }
        [JsonProperty("finalDate")]
        public DateTime FinalDate { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
    }
}
