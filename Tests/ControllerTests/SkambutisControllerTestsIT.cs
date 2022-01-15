using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testavimas_1.Models;
using Xunit;

namespace Tests.ControllerTests
{
    public class SKambutisControllerTestsIT : IClassFixture<WebApplicationFactory<Testavimas_1.Startup>>
    {
        private readonly WebApplicationFactory<Testavimas_1.Startup> _factory;

        public SKambutisControllerTestsIT(WebApplicationFactory<Testavimas_1.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Skambutis/List")]
        [InlineData("/Skambutis/Details/6")]
        [InlineData("/Skambutis/Create")]
        [InlineData("/Skambutis/Edit")]
        public async Task GETEndpointsTest(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

 /*       [Theory]
        [InlineData("/Skambutis/Create")]
        public async Task POSTEndpointsTest(string url)
        {
            var client = _factory.CreateClient();

            var skambutis = new Skambutis(true, DateTime.Now, 6, 123);
            string json = JsonConvert.SerializeObject(skambutis);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, data);

            Assert.Contains("Skambutis/List", response.RequestMessage.RequestUri.AbsolutePath);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }*/

        /*[Theory]
        [InlineData("/Skambutis/Delete/2")]
        public async Task TestDelete(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }*/
    }
}
