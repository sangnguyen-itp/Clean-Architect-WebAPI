using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public class DatetimeHelper
    {
        private Int64 _01011900 => DateTimeOffset.ParseExact("01.01.1900", ddMMyyyy, new CultureInfo("en-US")).ToUnixTimeSeconds();
        private string ddMMyyyy => "dd.MM.yyyy";

        public DatetimeHelper()
        {

        }

        public Int64 GetDefaultUnixTime()
        {
            return _01011900;
        }

        public string DDMMYYY()
        {
            return ddMMyyyy;
        }
    }
}
