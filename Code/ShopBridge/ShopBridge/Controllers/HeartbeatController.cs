using ShopBridge.Common;
using ShopBridgeDBAccess.Common;
using ShopBridgeWebApi.Common;
using System;
using System.Web.Http;

namespace ShopBridgeWebApi.Controllers
{
    /// <summary>
    /// HeartbeatController is a controller which handles the requests and provides response to
    /// monitor the performance of shop bridge web api. 
    /// </summary>
    public class HeartbeatController : ApiController
    {
        /// <summary>
        /// CheckConnection is an api that ensures that the web api is running.
        /// </summary>
        /// <returns>message</returns>
        [HttpGet]
        public IHttpActionResult CheckConnection()
        {
            try
            {
                if (ShopBridgeDBAccessGenerator.ItemRepository != null)
                {
                    return Ok(Constants.HEARTBEAT_MESSAGE);
                }
                else
                {
                    throw new ShopBridgeException(Constants.DATABASE_ACCESS_MESSAGE);
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
