using WeatherClient.Controller;
using WeatherClient.Model;
using WeatherClient.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherClient
{
	internal class Program
	{
        public static void Main(string[] args)
        {
            try
            {

                var result1 = SMHIController.GetMeanTemperature().Result;
                Console.WriteLine("The average temperature in Sweden for the last hour was {0} degrees Celcius", result1);

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();

                var result2 = SMHIController.GetRainFall().Result;
                Console.WriteLine("Between {0} and {1} the total rainfall in Lund was {2} millimeters", result2.From, result2.To, result2.ValueData);

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();


                CancellationTokenSource cts = new CancellationTokenSource();
                var result3 = SMHIController.GetAllTemperatures().Result;



                foreach (Station st in result3.Station)
                {
                    if (st.Values != null)
                    {
                        foreach (Value v in st.Values)
                        {


                            if (!Console.KeyAvailable)
                            {
                                Console.WriteLine(st.Name + ':' + v.ValueData);

                                Thread.Sleep(100);

                            }
                            else
                            {
                                break;
                            }

                        }

                    }

                }

                if (Console.KeyAvailable)
                {
                    Console.WriteLine("Operation was aborted by key:");
                    Console.ReadKey();
                }

                Console.WriteLine("\n \nDone! Press any key to exit...");
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine("Type: " + e.GetType() + "\nMessage: " + e.Message + "\nInner Exception:" 
                    + e.InnerException + "\nStacktrace: " + e.InnerException.StackTrace);
                Console.WriteLine("\n" + ExceptionHandler.Explain(e));

                Console.ReadKey();
            
            }
        }

    }
}
