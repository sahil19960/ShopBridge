using ShopBridgeDBAccess.Common;
using ShopBridgeDBAccess.Models;
using ShopBridgeDBAccess.Repositories;
using ShopBridgeWebApi.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridgeWebApi.Controllers
{
    /// <summary>
    /// HeartbeatController is a controller which handles the requests and provides response to
    /// monitor the performance of shop bridge web api. 
    /// </summary>
    public class InventoryController : ApiController
    {
        private IItemRepository ItemRepository { get; set; }

        public InventoryController()
        {
            ItemRepository = ShopBridgeDBAccessGenerator.ItemRepository;
        }

        /// <summary>
        /// AddInventoryItem is an api used for the purpose of adding item in the inventory.
        /// </summary>
        /// <param name="item">item</param>
        /// <returns>message</returns>
        [HttpPost]
        public IHttpActionResult AddItem(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ItemRepository.AddItem(item);
                    return Ok(Constants.ITEM_ADDED_MESSAGE);
                }
                else
                {
                    return BadRequest(Constants.INVALID_DATA_MESSAGE);
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// GetItems is an api used for the purpose of getting items from the inventory.
        /// </summary>
        /// <returns>message</returns>
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            return Ok(ItemRepository.GetItems());
        }

        /// <summary>
        /// DeleteItem is an api used for the purpose of deleting item from the inventory.
        /// </summary>
        /// <param name="itemId">itemId</param>
        [HttpDelete]
        public HttpResponseMessage DeleteItem(int itemId)
        {
            try
            {
                var item = ItemRepository.GetItem(itemId);

                if (item == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, Constants.ITEM_NOT_FOUND_MESSAGE);
                }
                else
                {
                    ItemRepository.DeleteItem(item);
                    return Request.CreateResponse(HttpStatusCode.Accepted, Constants.DELETED);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// UpdateItem is an api used for the purpose of updating item from the inventory.
        /// </summary>
        /// <param name="item">item</param>
        [HttpPut]
        public HttpResponseMessage UpdateItem(Item item)
        {
            try
            {
                if (item.Name != null && item.Name == string.Empty)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, Constants.INVALID_DATA_MESSAGE);
                }
                else
                {
                    var existingItem = ItemRepository.GetItem(item.ItemId);

                    if (existingItem == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NoContent, Constants.ITEM_NOT_FOUND_MESSAGE);
                    }
                    else
                    {
                        ItemRepository.UpdateItem(item);
                        return Request.CreateResponse(HttpStatusCode.OK, Constants.UPDATED);
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
