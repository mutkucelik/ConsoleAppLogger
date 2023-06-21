﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLogger.Entities
{
    public class User : BaseEntity
    {
        public string UserNameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CreateDateString { get; set; }
    }
}
