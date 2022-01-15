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
    public class DarbuotojasControllerTestsIT : IClassFixture<WebApplicationFactory<Testavimas_1.Startup>>
    {
        private readonly WebApplicationFactory<Testavimas_1.Startup> _factory;

        public DarbuotojasControllerTestsIT(WebApplicationFactory<Testavimas_1.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Darbuotojas/List")]
        [InlineData("/Darbuotojas/Details/3")]
        [InlineData("/Darbuotojas/Create")]
        [InlineData("/Darbuotojas/Edit")]
        public async Task GETEndpointsTest(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

/*        [Theory]
        [InlineData("/Darbuotojas/Create")]
        public async Task POSTEndpointsTest(string url)
        {
            var client = _factory.CreateClient();

/*          neveikia nes controlleris priima [FromForm] duomenis, o ne json
            var darbuotojas = new Darbuotojas("Karolis", "Kaunas");
            string json = JsonConvert.SerializeObject(darbuotojas);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, data);

            Assert.Contains("Darbuotojas/List", response.RequestMessage.RequestUri.AbsolutePath);
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    */
        /*[Theory]
        [InlineData("/Darbuotojas/Delete/3")]
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
