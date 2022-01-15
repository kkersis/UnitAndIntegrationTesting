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
    public class DarbuotojasServiceTest
    {
        private readonly Mock<IDarbuotojasRepository> _repository;
        private readonly IDarbuotojasService _service;

        public DarbuotojasServiceTest()
        {
            _repository = new Mock<IDarbuotojasRepository>();
            _service = new DarbuotojasService(_repository.Object);
        }

        [Fact]
        public async Task TestGetAll()
        {
            var darbuotojaiList = new List<Darbuotojas>
            {
                new Darbuotojas
                {
                    Id = 1,
                    Vardas = "Petras",
                    Miestas = "Vilnius"
                }
            };

            _repository.Setup(x => x.FindAll()).Returns(Task.FromResult(darbuotojaiList));

            var result = await _service.GetAll();

            Assert.Equal(darbuotojaiList, result);
        }

        [Fact]
        public async Task TestGetNameById()
        {
            var darbuotojas = new Darbuotojas(1, "Juozas", "Kaunas");

            _repository.Setup(x => x.FindById(It.IsAny<int>())).Returns(Task.FromResult(darbuotojas));

            var result = await _service.GetNameById(2);

            Assert.Equal("Juozas", result);
        }

        [Fact]
        public async Task TestAdd()
        {
            var darbuotojas = new Darbuotojas();

            _repository.Setup(x => x.Save(It.IsAny<Darbuotojas>())).Returns(Task.FromResult(darbuotojas));

            var result = await _service.AddOrUpdate(darbuotojas);

            _repository.Verify(r => r.Save(It.IsAny<Darbuotojas>()), Times.Once);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestUpdate()
        {
            var darbuotojas = new Darbuotojas();
            var result = await _service.AddOrUpdate(darbuotojas);
            _repository.Verify(r => r.Save(It.IsAny<Darbuotojas>()), Times.Once);
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
            var darbuotojas = new Darbuotojas(1, "", "");

            _repository.Setup(x => x.FindById(It.IsAny<int>())).Returns(Task.FromResult(darbuotojas));

            var result = await _service.GetById(2);

            Assert.Equal(darbuotojas, result);
        }
    }
}
