using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using BeerDowser9000.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace Test
{





    [TestClass]
    public class Tests 
    {
        public List<BeerModel> allBeersCache;
        public List<ImageModel> imagesCache;
        private List<BeerModel> _beerPlaces = new List<BeerModel>();


        [TestMethod]
        public async void asyncApiCallTest() 
        {

            string filterFurther = "new york";

            string loc = "locquery";


            string url = "http://beermapping.com/webservice/" + loc + "/45b31d04baa8c587b9b55036dd35bf44/" + filterFurther + "&s=json";

            var hc = new HttpClient();
            var stream = await hc.GetStreamAsync(url);

            var serializer = new DataContractJsonSerializer(typeof(List<BeerModel>));
            allBeersCache = (List<BeerModel>)serializer.ReadObject(stream);
            _beerPlaces = allBeersCache;

            Assert.AreEqual(_beerPlaces, allBeersCache);



            //string one = "1";
            //string two = "2";
            //Assert.AreEqual(one, one);

        }

        [TestMethod]
        public void Test2() 
        {
            string one = "1";
            string two = "2";
            Assert.AreEqual(one, one);

        }



    }
}
