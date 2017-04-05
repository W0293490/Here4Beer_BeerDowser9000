using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Test1CreateNote()//tests creating notes
        {

            string loc = "";
            if (allBeersCache != null)
            {
                return allBeersCache;
            }

            if (filter == "State / Province")
            {
                loc = "locstate";
            }
            else if (filter == "City")
            {
                loc = "loccity";
            }
            else if (filter == "Location")
            {
                loc = "locquery";
            }

            string url = "http://beermapping.com/webservice/" + loc + "/45b31d04baa8c587b9b55036dd35bf44/" + filterFurther + "&s=json";

            var hc = new HttpClient();
            var stream = await hc.GetStreamAsync(url);

            var serializer = new DataContractJsonSerializer(typeof(List<BeerModel>));
            allBeersCache = (List<BeerModel>)serializer.ReadObject(stream);
            return allBeersCache;
        }
        }
    }
}
