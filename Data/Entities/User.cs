﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public required string Username { get; set; }

        [MinLength(8)]
        public required string Password { get; set; }
    }
}
