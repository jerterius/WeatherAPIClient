using WeatherClient.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Model
{
    [DataContract]
    public class Value
    {
        public Value() { }

        public Value(DateTime from, DateTime to, double value) {
            this.From = from;
            this.To = to;
            this.ValueDataSerialized = value.ToString();
        }


        
        public DateTime From { get; set; }
        [DataMember(Name = "from")]
        public Int64 FromSerialized { get; set; }


        public DateTime To { get; set; }
        [DataMember(Name = "to")]
        public Int64 ToSerialized { get; set; }

        [DataMember(Name = "ref")]
        public string Ref { get; set; }


        [DataMember(Name = "date")]
        public object Date { get; set; }

        public double ValueData { get; set; }
        [DataMember(Name = "value")]
        public string ValueDataSerialized { get; set; }

        [DataMember(Name = "quality")]
        public string Quality { get; set; }



        [OnDeserialized]
        void OnDeserializing(StreamingContext context)
        {
            try
            {

                if (this.FromSerialized == 0)
                {
                    this.From = default(DateTime);
                }
                else
                {
                    this.From = JsonConvert.DeserializeObject<DateTime>(UnixDateTimeNanoConverter.Convert(FromSerialized));
                }

                if (this.ToSerialized == 0)
                {
                    this.To = default(DateTime);
                }
                else
                {
                    this.To = JsonConvert.DeserializeObject<DateTime>(UnixDateTimeNanoConverter.Convert(ToSerialized));
                }

                if (Double.TryParse(ValueDataSerialized, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double doubleValue))
                {
                    ValueData = doubleValue;

                }
            }catch (Exception e)
            {
                throw e;
            }
        }


    }
}
