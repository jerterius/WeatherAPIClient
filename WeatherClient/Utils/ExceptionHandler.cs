using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Utils
{
    public static class ExceptionHandler
    {

        public static string Explain(Exception e)
        {
            string message = e.InnerException.ToString();

            if (message.Contains("Json"))
            {
                message = "API input is incorrect. Check API endpoint.";
            }

            return message;
        }
    }
}
