﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Allocations.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string RollName { get; set; }

        public Roll Roll { get; set; }
    }

}
