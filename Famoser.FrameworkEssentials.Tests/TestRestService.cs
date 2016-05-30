using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Famoser.FrameworkEssentials.Models.RestService;
using Famoser.FrameworkEssentials.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Famoser.FrameworkEssentials.Tests
{
    [TestClass]
    public class TestRestService
    {
        private string _testUri = "https://api.frameworkessentials.famoser.ch";

        [TestMethod]
        public async Task TestJsonPost()
        {
            //arrange
            var service = new RestService();
            var json = "{\"content\":\"hallo welt\"}";
        
            //act
            var res = await service.PostJsonAsync(new Uri(_testUri), json);

            //assert
            Assert.IsTrue(res.IsRequestSuccessfull, res.Exception?.ToString());
            if (res.IsRequestSuccessfull)
            {
                var response = await res.GetResponseAsStringAsync();

                //assert
                Assert.IsTrue(response.Contains(json));
                Assert.IsTrue(response.StartsWith("start"));
                Assert.IsTrue(response.EndsWith("end"));
            }
        }

        [TestMethod]
        public async Task TestJsonFilePost()
        {
            //arrange
            var service = new RestService();
            var json = "{\"content\":\"hallo welt\"}";
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets/content.config");
            var str = File.ReadAllBytes(fileName);

            //act
            var res = await service.PostJsonAsync(new Uri(_testUri), json, new List<RestFile>()
            {
                new RestFile() { Content = str, ContentName = "fileContent", FileName = "fileName"}
            });

            //assert
            Assert.IsTrue(res.IsRequestSuccessfull, res.Exception?.ToString());
            if (res.IsRequestSuccessfull)
            {
                var response = await res.GetResponseAsStringAsync();
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Assets/response_json.txt"), response);

                //assert
                Assert.IsTrue(response.Contains("hallo welt"));
                Assert.IsTrue(response.Contains("content"));
                Assert.IsTrue(response.Contains("fileName"));
                Assert.IsTrue(response.StartsWith("start"));
                Assert.IsTrue(response.EndsWith("end"));
            }
        }

        [TestMethod]
        public async Task TestFilePost()
        {
            //arrange
            var service = new RestService();
            var keyVal = new[]
            {
                new KeyValuePair<string, string>("key", "val"),
                new KeyValuePair<string, string>("key2", "val2"),
                new KeyValuePair<string, string>("key3", "val3"),
            };
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets/content.config");
            var str = File.ReadAllBytes(fileName);

            var list = new List<RestFile>
            {
                new RestFile()
                {
                    Content = str,
                    ContentName = "content",
                    FileName = "my filename"
                },
                new RestFile()
                {
                    Content = str,
                    ContentName = "content 2",
                    FileName = "my filename 2"
                }
            };

            //act
            var res = await service.PostAsync(new Uri(_testUri), keyVal, list);

            //assert
            Assert.IsTrue(res.IsRequestSuccessfull, res.Exception?.ToString());
            if (res.IsRequestSuccessfull)
            {
                var response = await res.GetResponseAsStringAsync();
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Assets/response.txt"), response);
                var text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Assets/regex.txt"));

                //assert
                Assert.IsTrue(Regex.IsMatch(response, text));
                Assert.IsTrue(response.StartsWith("start"));
                Assert.IsTrue(response.EndsWith("end"));
            }
        }
    }
}
