using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Models;

namespace Testavimas_1.Data
{
    public class DarbuotojasRepository : IDarbuotojasRepository
    {
        private readonly TestavimasContext _context;

        public DarbuotojasRepository(TestavimasContext context)
        {
            _context = context;
        }

        // prideda nauja arba atnaujina esanti
        public async Task<Darbuotojas> Save(Darbuotojas darbuotojas)
        {
            var darbuotojasInDb = await _context.Darbuotojai.FirstOrDefaultAsync(x => x.Id == darbuotojas.Id);

            if (darbuotojasInDb == null)
            {
                await _context.AddAsync(darbuotojas);
            }
            else
            {
                darbuotojasInDb.Vardas = darbuotojas.Vardas;
                darbuotojasInDb.Miestas = darbuotojas.Miestas;
            }
            await _context.SaveChangesAsync();

            return darbuotojas;
        }

        public async Task<Darbuotojas> Delete(Darbuotojas darbuotojas)
        {
            if (darbuotojas != null)
            {
                _context.Remove(darbuotojas);
                await _context.SaveChangesAsync();
            }

            return darbuotojas;
        }

        public async Task<Darbuotojas> FindById(int id)
        {
            var darbuotojas = await _context.Darbuotojai.FirstOrDefaultAsync(x => x.Id == id);
            return darbuotojas;
        }

        public async Task<List<Darbuotojas>> FindAll()
        {
            var darbuotojai = await _context.Darbuotojai.ToListAsync();
            return darbuotojai;
        }

        public async Task<List<Darbuotojas>> FindByVardas(string vardas)
        {
            var darbuotojai = await _context.Darbuotojai.Where(x => x.Vardas == vardas).ToListAsync();
            return darbuotojai;
        }

        public async Task<Darbuotojas> DeleteById(int id)
        {
            var darbuotojas = await _context.Darbuotojai.FirstOrDefaultAsync(x => x.Id == id);

            if (darbuotojas != null)
            {
                _context.Darbuotojai.Remove(darbuotojas);
                await _context.SaveChangesAsync();
            }

            return darbuotojas;
        }
    }
}
