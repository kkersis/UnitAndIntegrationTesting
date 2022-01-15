using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testavimas_1.Models;
using Testavimas_1.Services;

namespace Testavimas_1.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DarbuotojasApiController : ControllerBase
    {
        private readonly IDarbuotojasService _service;

        public DarbuotojasApiController(IDarbuotojasService service)
        {
            _service = service;
        }

        // GET: api/DarbuotojasApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Darbuotojas>>> GetDarbuotojai()
        {
            return await _service.GetAll();
        }

        // GET: api/DarbuotojasApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Darbuotojas>> GetDarbuotojas(int id)
        {
            var darbuotojas = await _service.GetById(id);

            if (darbuotojas == null)
            {
                return NotFound();
            }

            return darbuotojas;
        }

        // PUT: api/DarbuotojasApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDarbuotojas(int id, Darbuotojas darbuotojas)
        {
            if (id != darbuotojas.Id)
            {
                return BadRequest();
            }

            await _service.AddOrUpdate(darbuotojas);

            return NoContent();
        }

        // POST: api/DarbuotojasApi
        [HttpPost]
        public async Task<ActionResult<Darbuotojas>> PostDarbuotojas(Darbuotojas darbuotojas)
        {
            await _service.AddOrUpdate(darbuotojas);

            return CreatedAtAction("GetDarbuotojas", new { id = darbuotojas.Id }, darbuotojas);
        }

        // DELETE: api/DarbuotojasApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDarbuotojas(int id)
        {
            var darbuotojas = await _service.GetById(id);
            if (darbuotojas == null)
            {
                return NotFound();
            }

            await _service.DeleteById(id);

            return NoContent();
        }
    }
}
