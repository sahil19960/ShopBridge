using ShopBridgeDBAccess.Repositories;

namespace ShopBridgeDBAccess.Common
{
    /// <summary>
    /// ShopBridgeDBAccessGenerator is an entity that represents a generator 
    /// for accessing DB context instance.
    /// </summary>
    public static class ShopBridgeDBAccessGenerator
    {
        public static IItemRepository ItemRepository { get; set; }

        static ShopBridgeDBAccessGenerator()
        {
            ItemRepository = new ItemRepository();
        }
    }
}
