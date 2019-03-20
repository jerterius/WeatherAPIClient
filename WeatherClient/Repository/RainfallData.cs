using System.Runtime.Serialization;
using System.Collections.Generic;
using WeatherClient.Model;

namespace WeatherClient.Repository
{
    [DataContract]
    class RainfallData
    {
        [DataMember(Name = "value")]
        public List<Value> Values { get; set; }
    }
}

