using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Data;
using Testavimas_1.Models;

namespace Testavimas_1.Services
{
    public class SkambutisService : ISkambutisService
    {
        private readonly ISkambutisRepository _repository;

        public SkambutisService(ISkambutisRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Skambutis>> GetAll()
        {
            return await _repository.FindAll();
        }

        public async Task<DateTime> GetTimeById(int id)
        {
            var skambutis = await _repository.FindById(id);

            return skambutis.Laikas;
        }

        public async Task<Skambutis> DeleteById(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<Skambutis> AddOrUpdate(Skambutis skambutis)
        {
            return await _repository.Save(skambutis);
        }

        public async Task<Skambutis> GetById(int id)
        {
            return await _repository.FindById(id);
        }
    }
}
