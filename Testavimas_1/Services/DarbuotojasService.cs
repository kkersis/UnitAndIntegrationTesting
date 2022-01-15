using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Data;
using Testavimas_1.Models;

namespace Testavimas_1.Services
{
    public class DarbuotojasService : IDarbuotojasService
    {
        private readonly IDarbuotojasRepository _repository;

        public DarbuotojasService(IDarbuotojasRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Darbuotojas>> GetAll()
        {
            return await _repository.FindAll();
        }

        public async Task<string> GetNameById(int id)
        {
            var darbuotojas = await _repository.FindById(id);

            return darbuotojas.Vardas;
        }

        public async Task<Darbuotojas> DeleteById(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<Darbuotojas> AddOrUpdate(Darbuotojas darbuotojas)
        {
            return await _repository.Save(darbuotojas);
        }

        public async Task<Darbuotojas> GetById(int id)
        {
            return await _repository.FindById(id);
        }
    }
}
