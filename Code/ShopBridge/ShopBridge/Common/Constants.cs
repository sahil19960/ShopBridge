namespace ShopBridgeWebApi.Common
{
    /// <summary>
    /// Constants is an entity that represents constants used in shop bridge web api.
    /// </summary>
    internal static class Constants
    {
        public const string HEARTBEAT_MESSAGE = "Shop Bridge API is running.";
        public const string DATABASE_ACCESS_MESSAGE = "Can't access database.";

        #region Inventory

        public const string INVALID_DATA_MESSAGE = "Invalid request data.";
        public const string ITEM_ADDED_MESSAGE = "Item Added";
        public const string ITEM_NOT_FOUND_MESSAGE = "Item Not Found";
        public const string DELETED = "Item Deleted";
        public const string UPDATED = "Item Updated";

        #endregion
    }
}