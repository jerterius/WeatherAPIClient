using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Model
{
    [DataContract]
    public class Station
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "owner")]
        public string Owner { get; set; }

        [DataMember(Name = "from")]
        public object From { get; set; }

        [DataMember(Name = "to")]
        public object To { get; set; }

        [DataMember(Name = "height")]
        public double Height { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "value")]
        public List<Value> Values { get; set; }
    }
}
