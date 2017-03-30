using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using BeerDowser9000.Models;
using System.Runtime.Serialization.Json;

namespace BeerDowser9000.Controllers
{
    class SearchEngine
    {

        public static string query = ""; // city name, state name, brewery name - from search query element
        public static string filter = ""; // loccity, locstate, locquery from search filter element
        public static string apiKey = "45b31d04baa8c587b9b55036dd35bf44"; 
        public static string url = "http://beermapping.com/webservice/"; // base url

        // Example code from NamedayDemo5::
        private static List<BeerModel> beers;
        public static async Task<List<BeerModel>> RetrieveData()
        {
            if (beers != null)
            {
                return beers;
            }
            var hc = new HttpClient();
            var stream = await hc.GetStreamAsync(
                url + filter + "/" + apiKey + "/" + query + "&s=json");

            var serializer = new DataContractJsonSerializer(
                typeof(List<BeerModel>));

            beers =
                (List<BeerModel>)serializer.ReadObject(stream);

            return beers;
        }

        private List<BeerModel> results = new List<BeerModel>();
        private async void LoadData()
        {
            results = await SearchEngine.RetrieveData();
        }
    }
}
