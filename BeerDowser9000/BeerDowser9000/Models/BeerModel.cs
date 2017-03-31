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
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string reviewlink { get; set; }
        [DataMember]
        public string proxylink { get; set; }
        [DataMember]
        public string blogmap { get; set; }
        [DataMember]
        public string street { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string zip { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string overall { get; set; }
        [DataMember]
        public string imagecount { get; set; }
        //List<ImageModel> images { get; set; }

        //[DataMember]
        //public IEnumerable<ImageModel> images { get; set; }

        //public BeerModel(string name)
        //{
        //    this.name = name;
        //}

        public BeerModel()
        {

        }

        public string NamesAsString => string.Join(", ", name);

        //public string NamesAsString => string.Join(", ", name);
    }
}