﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Name { get; set; }
        public Int64 DOB { get; set; }
        public string Address { get; set; }
    }
}
