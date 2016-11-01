using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarT_Garden_UWP_Models.Models
{
    public class UserRole
    {
        [JsonProperty("id")]
        public int User_role_id { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
