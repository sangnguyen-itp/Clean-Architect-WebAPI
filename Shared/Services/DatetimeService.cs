using Application.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructures.Shared.Services
{
    public class DatetimeService : IDatetimeService
    {
        public DateTime NowUTC => DateTime.UtcNow;
    }
}
