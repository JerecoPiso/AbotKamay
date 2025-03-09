using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abot_Kamay_Tracking_and_Queuing_System.Models
{
    public class Barangay
    {
        [JsonProperty("brgy_code")]
        public string BrgyCode { get; set; }

        [JsonProperty("brgy_name")]
        public string BrgyName { get; set; }

        [JsonProperty("city_code")]
        public string CityCode { get; set; }

        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }
    }
}
