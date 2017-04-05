using BeerDowser9000.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;

namespace BeerDowser9000
{
    public class Repository
    {
        private static List<BeerModel> allBeersCache;
        private static List<ImageModel> imagesCache; 

        public static async Task<List<ImageModel>> GetImagesAsync(int id)
        {
            string url = "http://beermapping.com/webservice/locimage/45b31d04baa8c587b9b55036dd35bf44/" + id + "&s=json";

            var hc = new HttpClient();
            var stream = await hc.GetStreamAsync(url);
            var serializer = new DataContractJsonSerializer(typeof(List<ImageModel>));
            imagesCache = (List<ImageModel>)serializer.ReadObject(stream);
            return imagesCache;
        }

        public static async Task<List<BeerModel>> GetAllBeersAsync(string filter, string filterFurther) 
        {
            string loc = "";

            if (filter == "State/Province" && filterFurther.Length > 0)
            {
                loc = "locstate";
            }
            else if (filter == "City" && filterFurther.Length > 0)
            {
                loc = "loccity";
            }
            else if (filter == "Location" && filterFurther.Length > 0)
            {
                loc = "locquery";
            }
            // Construct API call through form functions:
            string url = "http://beermapping.com/webservice/" + loc + "/45b31d04baa8c587b9b55036dd35bf44/" + filterFurther + "&s=json";

            var hc = new HttpClient();
            var stream = await hc.GetStreamAsync(url);

            var serializer = new DataContractJsonSerializer(typeof(List<BeerModel>));
            allBeersCache = (List<BeerModel>)serializer.ReadObject(stream);
            return allBeersCache;
        }
    }
}
