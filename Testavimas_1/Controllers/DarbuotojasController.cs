using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Models;
using Testavimas_1.Services;

namespace Testavimas_1.Controllers
{
    public class DarbuotojasController : Controller
    {
        private readonly IDarbuotojasService _service;

        public DarbuotojasController(IDarbuotojasService service)
        {
            _service = service;
        }

        public async Task<ViewResult> List()
        {
            var darbuotojai = await _service.GetAll();

            return View(darbuotojai);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                await _service.AddOrUpdate(darbuotojas);
                return RedirectToAction("List");
            }
            else
            {
                return View(darbuotojas);
            }
        }

        public async Task<ViewResult> Details(int id)
        {
            var darbuotojas = await _service.GetById(id);

            return View(darbuotojas);
        }

        public async Task<ViewResult> Edit(int id)
        {
            var darbuotojas = await _service.GetById(id);

            return View(darbuotojas);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteById(id);

            return RedirectToAction("List");
        }

        public async Task<JsonResult> GetAllJson()
        {
            var darbuotojai = await _service.GetAll();

            return Json(darbuotojai);
        }
    }
}
