using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Model
{
    public class SensorBelow
    {
        public int Id { get; set; }

        public double Temp { get; set; }

        public double Humid { get; set; }

        public double Light { get; set; }

        public int UserId { get; set; }

        public DateTime Time_Of_Record { get; set; }

        public virtual User user { get; set; }
    }
}
