using System.Collections.Generic;
using System.Threading.Tasks;
using Testavimas_1.Models;

namespace Testavimas_1.Services
{
    public interface IDarbuotojasService
    {
        Task<Darbuotojas> DeleteById(int id);
        Task<List<Darbuotojas>> GetAll();
        Task<string> GetNameById(int id);
        Task<Darbuotojas> AddOrUpdate(Darbuotojas darbuotojas);
        Task<Darbuotojas> GetById(int id);

    }
}