using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abot_Kamay_Tracking_and_Queuing_System.Models
{
    public class Province
    {
        [JsonProperty("province_code")]
        public string ProvinceCode { get; set; }

        [JsonProperty("province_name")]
        public string ProvinceName { get; set; }

        public string PsgcCode { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }
    }
}
