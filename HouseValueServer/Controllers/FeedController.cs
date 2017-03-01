using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CelebriTweesServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeedController : ApiController
    {

        public FeedController()
        {
        }

        // POST feed/postarticle
        [HttpPost]
        [Route("feed/postarticle")]
        public IEnumerable<string> myAction()
        {
            return new[] {"value2"};
        }

        [HttpGet]
        [Route("feed/getfeed/{request}")]
        public IEnumerable<string> GetNewsFeed(string request)
        {
            return new[] {"value1", "value2"};
        }

        [HttpPost]
        [Route("feed/getestimate")]
        public double GetEstimate([FromBody] Property property)
        {
            return 5000;
        }

    }

    [DataContract]
    public class Test
    {
        [DataMember]
        public string Id { get; set; }
    }


    [DataContract]
    public class Property
    {
        [DataMember]
        public LatLng LatLng { get; set; }
        [DataMember]
        public int YearConstructed { get; set; }
        [DataMember]
        public double BuiltUpArea { get; set; }
        [DataMember]
        public double PlotSize { get; set; }
        [DataMember]
        public int Bathrooms { get; set; }
        [DataMember]
        public int Bedrooms { get; set; }
    }

    [DataContract]
    public enum PropertyType
    {
        [EnumMember]
        MultistoreyApartment,
        [EnumMember]
        BuilderFloorApartment,
        [EnumMember]
        ResidentialHouse,
        [EnumMember]
        Villa,
        [EnumMember]
        ResidentialPlot,
        [EnumMember]
        Penthouse,
        [EnumMember]
        Studio
    }

    [DataContract]
    public class LatLng
    {
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Lng { get; set; }
    }
}
