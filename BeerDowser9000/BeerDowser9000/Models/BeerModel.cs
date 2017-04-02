using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BeerDowser9000.Models
{
    public class BeerModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string reviewlink { get; set; }
        public string proxylink { get; set; }
        public string blogmap { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string url { get; set; }
        public string overall { get; set; }
        public string imagecount { get; set; }
        //List<ImageModel> images { get; set; }

        //[DataMember]
        //public IEnumerable<ImageModel> images { get; set; }

        //public BeerModel(string name)
        //{
        //    this.name = name;
        //}

        public BeerModel() {}

        public string Info
        {
            get { return "Welcome to " + name + ".\n\nThis " + status + 
                    " is located at " + street + ", " + city + ", " + state + 
                    ", " + country + ".\n\nPhone: " + phone + "."
                    ; }
        }



        //public string NamesAsString => string.Join(", ", name);
    }
}