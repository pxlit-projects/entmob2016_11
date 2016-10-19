using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Model
{
    public class Crop
    {
        public int Id { get; set; }

        public double Temp { get; set; }

        public double Humid { get; set; }

        public double Light { get; set; }

        public DateTime Time_Of_Year { get; set; }
    }
}
