using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden_UWP_Models
{
    public class Sensor
    {
        public int Id { get; set; }

        public double Temp { get; set; }

        public double Humid { get; set; }

        public double Light { get; set; }

        public DateTime Time_Of_Record { get; set; }

        public string UserName { get; set; }

        public virtual User user { get; set; }

        public int above { get; set; }
    }
}