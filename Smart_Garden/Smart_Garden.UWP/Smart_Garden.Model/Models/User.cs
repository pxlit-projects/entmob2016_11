﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password  { get; set; }

        public string Discriminator { get; set; }
    }
}
