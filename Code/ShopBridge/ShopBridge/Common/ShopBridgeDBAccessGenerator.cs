using ShopBridgeDBAccess.Repositories;

namespace ShopBridgeDBAccess.Common
{
    /// <summary>
    /// ShopBridgeDBAccessGenerator is an entity that represents a generator 
    /// for accessing DB context instance.
    /// </summary>
    public static class ShopBridgeDBAccessGenerator
    {
        private static ItemRepository _itemRepository;
        public static IItemRepository ItemRepository {
            get
            {
                if(_itemRepository == null)
                {
                    _itemRepository = new ItemRepository();
                }

                return _itemRepository;
            }
        }
    }
}
