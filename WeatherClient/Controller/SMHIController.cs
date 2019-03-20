using WeatherClient.Model;
using WeatherClient.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherClient.Controller
{
    static class SMHIController
    {
        public static async Task<double> GetMeanTemperature()
        {
            try
            {
                using (var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                using (HttpResponseMessage response =
                    await httpClient.GetAsync(new Uri("https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station-set/all/period/latest-hour/data.json")))

                {

                    var s = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<TemperatureData>(s);

                    List<double> temps = new List<double>();
                    foreach (Station st in model.Station)
                    {
                        if (st.Values != null)
                        {
                            foreach (Value v in st.Values)
                            {

                                if (Double.TryParse(v.ValueDataSerialized, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double doubleValue))
                                {
                                    temps.Add(doubleValue);

                                }

                            }

                        }

                    }
                    double meanTemp = temps.Sum() / temps.Count();

                    return meanTemp;

                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public static async Task<Value> GetRainFall()
        {
            try
            {
                using (var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                using (HttpResponseMessage response =
                    await httpClient.GetAsync(new Uri("https://opendata-download-metobs.smhi.se/api/version/latest/parameter/23/station/53430/period/latest-months/data.json")))




                {

                    string content = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<RainfallData>(content);

                    List<double> rainfall = new List<double>();
                    List<DateTime> dates = new List<DateTime>();
                    foreach (Value v in model.Values)
                    {

                        rainfall.Add(v.ValueData);

                        dates.Add(v.From);
                        dates.Add(v.To);

                    }

                    Value resultValue = new Value(dates.Min(), dates.Max(), rainfall.Sum());
                   
                    return resultValue;




                }
            

            } catch (Exception e)
            {
                throw e;
            }
        }


        public static async Task<TemperatureData> GetAllTemperatures()
        {
            try
            {
                
                using (var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) })
                using (HttpResponseMessage response =
                    await httpClient.GetAsync(new Uri("https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station-set/all/period/latest-hour/data.json")))

                {
                    var s = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<TemperatureData>(s);
                   
                    return model;

                }
            }
          

        
            catch (Exception e)
            {
                throw e;
            }

        }

    }

}
