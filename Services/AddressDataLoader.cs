using Abot_Kamay_Tracking_and_Queuing_System.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abot_Kamay_Tracking_and_Queuing_System.Services
{
    public class AddressDataLoader
    {
        public List<GeographicalRegion> Regions { get; set; }
        public List<Province> Provinces { get; set; }
        public List<City> Cities { get; set; }
        public List<Barangay> Barangays { get; set; }

        public void LoadData()
        {
            // Specify the path based on your project directory
            Regions = LoadJsonFile<List<GeographicalRegion>>("AddressData/region.json");
            Provinces = LoadJsonFile<List<Province>>("AddressData/province.json");
            Cities = LoadJsonFile<List<City>>("AddressData/city.json");
            Barangays = LoadJsonFile<List<Barangay>>("AddressData/barangay.json");
        }

        private T LoadJsonFile<T>(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
