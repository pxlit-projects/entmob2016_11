using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool enabled { get; set; }
        public List<object> sensorEntities { get; set; }
    }
}
