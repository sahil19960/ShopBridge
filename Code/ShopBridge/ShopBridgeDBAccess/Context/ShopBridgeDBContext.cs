using ShopBridgeDBAccess.Common;
using ShopBridgeDBAccess.Models;
using System.Data.Entity;

namespace ShopBridgeDBAccess.Context
{
    /// <summary>
    /// ShopBridgeDBContext is the DBContext entity for ShowBridge project.
    /// </summary>
    public class ShopBridgeDBContext: DbContext
    {
        public ShopBridgeDBContext(): base(Constants.CONNECTION_STRING_NAME)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopBridgeDBContext, Migrations.Configuration>());
        }

        public DbSet<Item> Items { get; set; }
    }
}
