using BeerDowser9000.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Collections.ObjectModel;

namespace BeerDowser9000
{
    class Repository
    {

        private static List<BeerModel> allBeersCache;

        public static async Task<List<BeerModel>> GetAllBeersAsync()
        {
            if (allBeersCache != null)
            {
                return allBeersCache;
            }
            var hc = new HttpClient();
            var stream = await hc.GetStreamAsync("http://beermapping.com/webservice/loccity/45b31d04baa8c587b9b55036dd35bf44/halifax&s=json");
            var serializer = new DataContractJsonSerializer(typeof(List<BeerModel>));
            allBeersCache = (List<BeerModel>)serializer.ReadObject(stream);
            return allBeersCache;
        }

    }

}
