using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShopBridgeDBAccess.Models;
using ShopBridgeDBAccess.Repositories;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace ShopBridgeUnitTest.InvetoryUnitTests
{
    [TestClass]
    public class ItemUnitTest
    {
        private IItemRepository IItemRepository { get; set; }

        public ItemUnitTest()
        {
            IItemRepository = new ItemRepository();
        }

        [TestMethod]
        public void AddItem()
        {
            var request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ShopBridgeWebApiEndpoint"] + "/AddItem/");
            request.ContentType = "application/json";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var item = new Item
                {
                    Name = "CadburyTest",
                    Description = "Chocolate",
                    Category = "Sweets",
                    Price = 12.11M
                };
                
                string postData = JsonConvert.SerializeObject(item);

                streamWriter.Write(postData);
                streamWriter.Flush();
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [TestMethod]
        public void UpdateItem()
        {
            var request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ShopBridgeWebApiEndpoint"] + "/UpdateItem/");
            request.ContentType = "application/json";
            request.Method = "PUT";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                var item = new Item
                {
                    ItemId = 1,
                    Name = "CadburyTest",
                    Description = "Chocolate",
                    Category = "Sweets",
                    Price = 12.11M
                };

                string postData = JsonConvert.SerializeObject(item);

                streamWriter.Write(postData);
                streamWriter.Flush();
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [TestMethod]
        public void DeleteItem()
        {
            var request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ShopBridgeWebApiEndpoint"] + "/DeleteItem" + "?itemId=1");
            request.ContentType = "application/json";
            request.Method = "DELETE";

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Assert.AreEqual(response.StatusCode, HttpStatusCode.Accepted);
            }
        }

        [TestMethod]
        public void GetItems()
        {
            var request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ShopBridgeWebApiEndpoint"] + "/GetItems/");
            request.ContentType = "application/json";
            request.Method = "Get";

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }
    }
}
