using ShopBridgeDBAccess.Common;
using ShopBridgeDBAccess.Context;
using ShopBridgeDBAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShopBridgeDBAccess.Repositories
{
    /// <summary>
    /// ItemRepository is the repository for managing inventory items.
    /// </summary>
    public class ItemRepository : IItemRepository
    {
        private ShopBridgeDBContext ShopBridgeContextInstance { get; set; }

        public ItemRepository()
        {
            ShopBridgeContextInstance = new ShopBridgeDBContext();
        }

        /// <summary>
        /// AddItem is the metod for adding item in the inventory.
        /// </summary>
        /// <param name="item">Item of inventory</param>
        public void AddItem(Item item)
        {
            using (DbContextTransaction transaction = ShopBridgeContextInstance.Database.BeginTransaction())
            {
                try
                {
                    item.Price = Convert.ToDecimal(Math.Round(Convert.ToDouble(item.Price), Constants.PRICE_PRECISION));
                    ShopBridgeContextInstance.Items.Add(item);
                    ShopBridgeContextInstance.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// GetItem is the metod for getting an item from the inventory.
        /// </summary>
        /// <param name="itemId">ItemId</param>
        /// <returns>Item</returns>
        public Item GetItem(int itemId)
        {
            try
            {
                return ShopBridgeContextInstance.Items.Where(x => x.ItemId == itemId).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// GetItems is the metod for getting an items from the inventory.
        /// </summary>
        /// <returns>List of Items</returns>
        public List<Item> GetItems()
        {
            try
            {
                return ShopBridgeContextInstance.Items.ToList();
            }
            catch(Exception)
            {
                return null;
            }       
        }

        /// <summary>
        /// DeleteItem is the metod for deleting an items from the inventory.
        /// </summary>
        /// <param name="item">Item Id of an item</param>
        public void DeleteItem(Item item)
        {
            using (DbContextTransaction transaction = ShopBridgeContextInstance.Database.BeginTransaction())
            {
                try
                {
                    ShopBridgeContextInstance.Items.Remove(item);
                    ShopBridgeContextInstance.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// UpdateItem is the metod for update an item in the inventory.
        /// </summary>
        /// <param name="item">Item of an inventory</param>
        public void UpdateItem(Item item)
        {
            using (DbContextTransaction transaction = ShopBridgeContextInstance.Database.BeginTransaction())
            {
                try
                {
                    var existingItem = ShopBridgeContextInstance.Items.Where(x => x.ItemId == item.ItemId).FirstOrDefault();

                    existingItem.Name = item.Name ?? existingItem.Name;
                    existingItem.Description = item.Description ?? existingItem.Description;
                    existingItem.Price = (item.Price != null)?
                        Convert.ToDecimal(Math.Round(Convert.ToDouble(item.Price), Constants.PRICE_PRECISION))
                            :existingItem.Price;
                    existingItem.Category = item.Category ?? existingItem.Category;

                    ShopBridgeContextInstance.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
