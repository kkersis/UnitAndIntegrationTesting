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
using Testavimas_1.ViewModels;
using Xunit;

namespace Tests.ControllerTests
{
    public class SkambutisControllerTests
    {
        private readonly Mock<ISkambutisService> _skambutisService;
        private readonly Mock<IDarbuotojasService> _darbuotojasService;


        public SkambutisControllerTests()
        {
            _skambutisService = new Mock<ISkambutisService>();
            _darbuotojasService = new Mock<IDarbuotojasService>();
        }

        [Fact]
        public async Task TestList()
        {
            _skambutisService.Setup(x => x.GetAll()).ReturnsAsync(new List<Skambutis>()
            {
                new Skambutis(true, DateTime.Now, 1, 20),
                new Skambutis(true, DateTime.Now, 1, 30),
                new Skambutis(true, DateTime.Now, 1, 40),
            });
            var controller = new SkambutisController(_skambutisService.Object, _darbuotojasService.Object);

            var result = await controller.List();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<Skambutis>>(viewResult.ViewData.Model);
            Assert.Equal(20, model.First().Trukme);
        }

        [Fact]
        public async Task TestDetails()
        {
            _skambutisService.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Skambutis(true, DateTime.Now, 1, 20));
            var controller = new SkambutisController(_skambutisService.Object, _darbuotojasService.Object);

            var result = await controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Skambutis>(viewResult.ViewData.Model);
            Assert.Equal(20, model.Trukme);
        }

        [Fact]
        public async Task TestCreate()
        {
            var skambutis = new Skambutis(true, DateTime.Now, 1, 20);
            _skambutisService.Setup(x => x.AddOrUpdate(It.IsAny<Skambutis>()))
                .ReturnsAsync(skambutis);
            var controller = new SkambutisController(_skambutisService.Object, _darbuotojasService.Object);

            var result = await controller.Create(skambutis);

            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            _skambutisService.Verify(s => s.AddOrUpdate(It.IsAny<Skambutis>()), Times.Once());
        }

        [Fact]
        public async Task TestDelete()
        {
            var skambutis = new Skambutis(true, DateTime.Now, 1, 20);
            _skambutisService.Setup(x => x.DeleteById(It.IsAny<int>()))
                .ReturnsAsync(skambutis);
            var controller = new SkambutisController(_skambutisService.Object, _darbuotojasService.Object);

            var result = await controller.Delete(1);

            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            _skambutisService.Verify(s => s.DeleteById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public async Task TestEdit()
        {
            _skambutisService.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Skambutis(true, DateTime.Now, 1, 20));
            var controller = new SkambutisController(_skambutisService.Object, _darbuotojasService.Object);

            var result = await controller.Edit(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<CreateSkambutisViewModel>(viewResult.ViewData.Model);
            Assert.Equal(20, model.Skambutis.Trukme);
        }
    }
}
