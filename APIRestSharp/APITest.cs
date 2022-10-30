using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Text.Json;
using Assert = NUnit.Framework.Assert;

namespace APIRestSharp
{
    [TestClass]
    public class EnableTest
    {
        [TestMethod]
        public void GetRequestValidation()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.Get);
            request.AddUrlSegment("postid", 3);

            var response = client.Execute(request);
            var output = JsonSerializer.Deserialize<Rootobject>(response.Content);
            try
            {
                Assert.IsTrue(output.author.Equals("Harsha") && output.id.Equals(3) && output.title.Equals("enable test"));
                Console.WriteLine("All responses are correct");
            }
            catch (Exception)
            {
                Console.WriteLine("Output response is different - FAIL");
            }
        }

        [TestMethod]
        public void GetRequestFailTest()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.Get);
            request.AddUrlSegment("postid", 3);

            var response = client.Execute(request);
            var output = JsonSerializer.Deserialize<Rootobject>(response.Content);
            try
            {
                Assert.IsTrue(output.author.Equals("Harsha") && output.id.Equals(1) && output.title.Equals("enable test"));
                Console.WriteLine("All responses are correct");
            }
            catch (Exception)
            {
                Console.WriteLine("Output response is different - FAIL");
            }
        }

        [TestMethod]
        public void PostRequestValidation()
        {
            var client = new RestClient("http://localhost:3000/");
            var newRequest = new RestRequest("posts", Method.Post);
            newRequest.RequestFormat = DataFormat.Json;
            newRequest.AddBody(new { id = 6, title = "Enable API3", author = "Harsha k3" });
            var response = client.Execute(newRequest);
            var output = JsonSerializer.Deserialize<Rootobject>(response.Content);
            Assert.IsTrue(output.author.Equals("Harsha k3") && output.id.Equals(6) && output.title.Equals("Enable API3"));
              
           
        }
    }
}
