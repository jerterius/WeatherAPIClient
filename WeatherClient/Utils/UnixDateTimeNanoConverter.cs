using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Utils
{
    public static class UnixDateTimeNanoConverter
    {
        public static string Convert(Int64 dateTime)
        {
            return @"""" + "/Date(" + dateTime + ")/" + @"""";
        }
    }
}
