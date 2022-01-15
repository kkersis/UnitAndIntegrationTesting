using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testavimas_1.Controllers;
using Testavimas_1.Data;
using Testavimas_1.Models;
using Testavimas_1.Services;
using Xunit;

namespace Tests.ControllerTests
{
    public class DarbuotojasControllerTests
    {
        private readonly Mock<IDarbuotojasService> _service;

        public DarbuotojasControllerTests()
        {
            _service = new Mock<IDarbuotojasService>();
        }

        [Fact]
        public async Task TestList()
        {
            _service.Setup(x => x.GetAll()).ReturnsAsync(new List<Darbuotojas>()
            {
                new Darbuotojas(1, "Lukas", "Vilnius"),
                new Darbuotojas(2, "Andrius", "Kaunas"),
                new Darbuotojas(3, "Petras", "Kedainiai")
            });
            var controller = new DarbuotojasController(_service.Object);

            var result = await controller.List();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<Darbuotojas>>(viewResult.ViewData.Model);
            Assert.Equal("Lukas", model.First().Vardas);
        }

        [Fact]
        public async Task TestDetails()
        {
            _service.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Darbuotojas(1, "Antanas", "Vilnius"));
            var controller = new DarbuotojasController(_service.Object);

            var result = await controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Darbuotojas>(viewResult.ViewData.Model);
            Assert.Equal("Antanas", model.Vardas);
        }

        [Fact]
        public async Task TestCreate()
        {
            var darbuotojas = new Darbuotojas(1, "Antanas", "Vilnius");
            _service.Setup(x => x.AddOrUpdate(It.IsAny<Darbuotojas>()))
                .ReturnsAsync(darbuotojas);
            var controller = new DarbuotojasController(_service.Object);

            var result = await controller.Create(darbuotojas);

            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            _service.Verify(s => s.AddOrUpdate(It.IsAny<Darbuotojas>()), Times.Once());
        }

        [Fact]
        public async Task TestDelete()
        {
            var darbuotojas = new Darbuotojas(1, "Antanas", "Vilnius");
            _service.Setup(x => x.DeleteById(It.IsAny<int>()))
                .ReturnsAsync(darbuotojas);
            var controller = new DarbuotojasController(_service.Object);

            var result = await controller.Delete(1);

            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            _service.Verify(s => s.DeleteById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public async Task TestEdit()
        {
            _service.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Darbuotojas(1, "Antanas", "Vilnius"));
            var controller = new DarbuotojasController(_service.Object);

            var result = await controller.Edit(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Darbuotojas>(viewResult.ViewData.Model);
            Assert.Equal("Antanas", model.Vardas);
        }
    }
}
