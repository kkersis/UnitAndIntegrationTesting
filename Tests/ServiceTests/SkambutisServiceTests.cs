using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testavimas_1.Data;
using Testavimas_1.Models;
using Testavimas_1.Services;
using Xunit;

namespace Tests.ServiceTests
{
    public class SkambutisServiceTest
    {
        private readonly Mock<ISkambutisRepository> _repository;
        private readonly ISkambutisService _service;

        public SkambutisServiceTest()
        {
            _repository = new Mock<ISkambutisRepository>();
            _service = new SkambutisService(_repository.Object);
        }

        [Fact]
        public async Task TestGetAll()
        {
            var skambuciaiList = new List<Skambutis>
            {
                new Skambutis()
                {
                    Id = 1,
                    Atsiliepta = true,
                    DarbuotojasId = 1,
                    Laikas = DateTime.Now,
                    Trukme = 123
                }
            };

            _repository.Setup(x => x.FindAll()).Returns(Task.FromResult(skambuciaiList));

            var result = await _service.GetAll();

            Assert.Equal(skambuciaiList, result);
        }

        [Fact]
        public async Task TestGetTimeById()
        {
            var timeNow = DateTime.Now;
            var skambutis = new Skambutis(1, true, timeNow, 1, 123);

            _repository.Setup(x => x.FindById(It.IsAny<int>())).Returns(Task.FromResult(skambutis));

            var result = await _service.GetTimeById(2);

            Assert.Equal(timeNow, result);
        }

        [Fact]
        public async Task TestAdd()
        {
            var skambutis = new Skambutis();

            _repository.Setup(x => x.Save(It.IsAny<Skambutis>())).Returns(Task.FromResult(skambutis));

            var result = await _service.AddOrUpdate(skambutis);

            _repository.Verify(r => r.Save(It.IsAny<Skambutis>()), Times.Once);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestUpdate()
        {
            var skambutis = new Skambutis();
            var result = await _service.AddOrUpdate(skambutis);
            _repository.Verify(r => r.Save(It.IsAny<Skambutis>()), Times.Once);
        }

        [Fact]
        public async Task TestDeleteById()
        {
            await _service.DeleteById(1);
            _repository.Verify(r => r.DeleteById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task TestGetById()
        {
            var skambutis = new Skambutis(1, true, DateTime.Now, 1, 123);

            _repository.Setup(x => x.FindById(It.IsAny<int>())).Returns(Task.FromResult(skambutis));

            var result = await _service.GetById(2);

            Assert.Equal(skambutis, result);
        }
    }
}
