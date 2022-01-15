using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Models;

namespace Testavimas_1.Data
{
    public class SkambutisRepository : ISkambutisRepository
    {
        private readonly TestavimasContext _context;

        public SkambutisRepository(TestavimasContext context)
        {
            _context = context;
        }

        // prideda nauja arba atnaujina esanti
        public async Task<Skambutis> Save(Skambutis skambutis)
        {
            var skambutisInDb = await _context.Skambuciai.FirstOrDefaultAsync(x => x.Id == skambutis.Id);

            if (skambutisInDb == null)
            {
                await _context.AddAsync(skambutis);
            }
            else
            {
                skambutisInDb.Atsiliepta = skambutis.Atsiliepta;
                skambutisInDb.DarbuotojasId = skambutis.DarbuotojasId;
                skambutisInDb.Laikas = skambutis.Laikas;
                skambutisInDb.Trukme = skambutis.Trukme;
            }
            await _context.SaveChangesAsync();

            return skambutis;
        }

        public async Task<Skambutis> Delete(Skambutis skambutis)
        {
            if (skambutis != null)
            {
                _context.Remove(skambutis);
                await _context.SaveChangesAsync();
            }

            return skambutis;
        }

        public async Task<Skambutis> FindById(int id)
        {
            var skambutis = await _context.Skambuciai.Include(x => x.Darbuotojas).FirstOrDefaultAsync(x => x.Id == id);
            return skambutis;
        }

        public async Task<List<Skambutis>> FindAll()
        {
            var skambuciai = await _context.Skambuciai.Include(s => s.Darbuotojas).ToListAsync();
            return skambuciai;
        }

        public async Task<Skambutis> DeleteById(int id)
        {
            var skambutis = await _context.Skambuciai.FirstOrDefaultAsync(x => x.Id == id);

            if (skambutis != null)
            {
                _context.Skambuciai.Remove(skambutis);
                await _context.SaveChangesAsync();
            }

            return skambutis;
        }
    }
}
