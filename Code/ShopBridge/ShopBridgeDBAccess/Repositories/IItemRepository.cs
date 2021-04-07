using ShopBridgeDBAccess.Models;
using System.Collections.Generic;

namespace ShopBridgeDBAccess.Repositories
{
    /// <summary>
    /// IItemRepository is the repository for managing inventory items.
    /// </summary>
    public interface IItemRepository
    {
        /// <summary>
        /// AddItem is the metod for adding item in the inventory.
        /// </summary>
        /// <param name="item">Item of inventory</param>
        void AddItem(Item item);

        /// <summary>
        /// GetItems is the metod for getting an items from the inventory.
        /// </summary>
        List<Item> GetItems();

        /// <summary>
        /// GetItem is the metod for getting an item from the inventory.
        /// </summary>
        /// <param name="itemId">ItemId of an Item</param>
        Item GetItem(int itemId);

        /// <summary>
        /// DeleteItem is the metod for deleting an item from the inventory.
        /// </summary>
        /// <param name="item">Item of inventory</param>
        void DeleteItem(Item item);

        /// <summary>
        /// UpdateItem is the metod for updating an item from the inventory.
        /// </summary>
        /// <param name="item">Item of inventory</param>
        void UpdateItem(Item item);
    }
}
