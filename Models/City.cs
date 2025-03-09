using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abot_Kamay_Tracking_and_Queuing_System.Models
{
    public class City
    {
        [JsonProperty("city_code")]
        public string CityCode { get; set; }

        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        [JsonProperty("psgc_code")]
        public string PsgcCode { get; set; }

        [JsonProperty("region_desc")]
        public string RegionDesc { get; set; }
    }
}
