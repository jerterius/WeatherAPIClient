using System.Runtime.Serialization;
using System.Collections.Generic;
using WeatherClient.Model;

namespace WeatherClient.Repository
{

    [DataContract]
    public class TemperatureData
    {
        [DataMember(Name = "station")]
        public List<Station> Station { get; set; }
    }
}
