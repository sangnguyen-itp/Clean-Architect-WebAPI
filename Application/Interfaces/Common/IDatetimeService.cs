﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Common
{
    public interface IDatetimeService
    {
        DateTime NowUTC { get; }
    }
}
