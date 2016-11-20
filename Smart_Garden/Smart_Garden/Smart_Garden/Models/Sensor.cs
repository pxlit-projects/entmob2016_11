using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        [JsonProperty("temperature")]
        public double Temp { get; set; }
        [JsonProperty("humidity")]
        public double Humid { get; set; }
        [JsonProperty("light")]
        public double Light { get; set; }
        [JsonProperty("time_of_recording")]
        public DateTime Time_Of_Record { get; set; }
        [JsonProperty("above")]
        public bool above { get; set; }
        [JsonProperty("user_id")]
        public virtual User user { get; set; }
    }
}
