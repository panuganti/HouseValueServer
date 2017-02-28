using System;
using System.Web.Http;
using GoogleDatastore;
using System.Web.Http.Cors;

namespace NewsSwipesServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeedController : Controller
    {
        Datastore _ds;


        public FeedController() 
        {
        }


        #region Test
        [HttpGet]
        [Route("feed/getfeed")]
        public Property GetFeed()
        {
            return new Property() { Address = "hello"}; 
        }
        #endregion Test

        [HttpPost]
        [Route("feed/getestimate")]
        public int GetEstimate([FromBody]Property property)
        {
            return property.Address.Length;
        }

    }
}
