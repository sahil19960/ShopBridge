using System;

namespace ShopBridge.Common
{
    /// <summary>
    /// ShopBridgeException is an entity that represents custom exception of shop bridge exception.
    /// </summary>
    public class ShopBridgeException:Exception
    {
        public ShopBridgeException(string message):base(message){}
    }
}