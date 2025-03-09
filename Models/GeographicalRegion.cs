using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abot_Kamay_Tracking_and_Queuing_System.Models
{
    public class GeographicalRegion
    {
        public int Id { get; set; }
        public string PsgcCode { get; set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; set; }

        [JsonProperty("region_name")]
        public string RegionName { get; set; }
    }
}
