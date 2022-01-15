using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Models;
using Testavimas_1.Services;
using Testavimas_1.ViewModels;

namespace Testavimas_1.Controllers
{
    public class SkambutisController : Controller
    {
        private readonly ISkambutisService _service;
        private readonly IDarbuotojasService _darbuotojasService;

        public SkambutisController(ISkambutisService service, IDarbuotojasService darbuotojasService)
        {
            _service = service;
            _darbuotojasService = darbuotojasService;
        }

        public async Task<ViewResult> List()
        {
            var skambuciai = await _service.GetAll();

            return View(skambuciai);
        }

        public async Task<ViewResult> Create()
        {
            var viewModel = new CreateSkambutisViewModel();
            viewModel.Darbuotojai = await _darbuotojasService.GetAll();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Skambutis skambutis)
        {
            if (ModelState.IsValid)
            {
                await _service.AddOrUpdate(skambutis);
                return RedirectToAction("List");
            }
            else
            {
                return View(skambutis);
            }
        }

        
        public async Task<ViewResult> Details(int id)
        {
            var skambutis = await _service.GetById(id);

            return View(skambutis);
        }

        
        public async Task<ViewResult> Edit(int id)
        {
            var viewModel = new CreateSkambutisViewModel();
            viewModel.Darbuotojai = await _darbuotojasService.GetAll();
            viewModel.Skambutis = await _service.GetById(id);
            return View(viewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteById(id);

            return RedirectToAction("List");
        }
    }
}
