using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testavimas_1.Data;
using Testavimas_1.Models;
using Xunit;

namespace Tests.ControllerTests
{
    public class DarbuotojasApiControllerTests : IClassFixture<WebApplicationFactory<Testavimas_1.Startup>>
    {
        private readonly WebApplicationFactory<Testavimas_1.Startup> _factory;
        private readonly TestavimasContext _context;

        public DarbuotojasApiControllerTests(WebApplicationFactory<Testavimas_1.Startup> factory)
        {
            _factory = factory;
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<TestavimasContext>();

            builder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Testavimas_1; Trusted_Connection = True; MultipleActiveResultSets = true")
                    .UseInternalServiceProvider(serviceProvider);

            _context = new TestavimasContext(builder.Options);
            _context.Database.Migrate();
        }

        [Fact]
        public async Task GetDarbuotojaiTest()
        {
            var darbuotojai = _context.Darbuotojai.ToArray();
            string url = "/api/DarbuotojasApi";
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);
            var resultList = JsonConvert.DeserializeObject<Darbuotojas[]>(await response.Content.ReadAsStringAsync());

            Assert.Equal(darbuotojai, resultList);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetDarbuotojasTest()
        {
            var darbuotojas = _context.Darbuotojai.FirstOrDefault(x => x.Id == 7);
            string url = "/api/DarbuotojasApi/7";
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);
            var result = JsonConvert.DeserializeObject<Darbuotojas>(await response.Content.ReadAsStringAsync());

            Assert.Equal(darbuotojas, result);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task PostDarbuotojasTest()
        {
            string url = "/api/DarbuotojasApi";
            var client = _factory.CreateClient();

            var darbuotojas = new Darbuotojas("Karolis", "Kaunas");
            string json = JsonConvert.SerializeObject(darbuotojas);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, data);

            var result = JsonConvert.DeserializeObject<Darbuotojas>(await response.Content.ReadAsStringAsync());

            Assert.Equal(darbuotojas.Vardas, result.Vardas);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task PutDarbuotojasTest()
        {
            string url = "/api/DarbuotojasApi/7";
            var client = _factory.CreateClient();

            var darbuotojas = new Darbuotojas(7, "Karolis", "Kaunas");
            string json = JsonConvert.SerializeObject(darbuotojas);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, data);

            var darbInDb = _context.Darbuotojai.FirstOrDefault(x => x.Id == 7);

            Assert.Equal(darbuotojas.Vardas, darbInDb.Vardas);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }

        /*[Fact]
        public async Task DeleteDarbuotojasTest()
        {
            string url = "/api/DarbuotojasApi/5";
            var client = _factory.CreateClient();

            var response = await client.DeleteAsync(url);

            var darbInDb = _context.Darbuotojai.FirstOrDefault(x => x.Id == 5);

            Assert.Null(darbInDb);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }*/
    }
}
