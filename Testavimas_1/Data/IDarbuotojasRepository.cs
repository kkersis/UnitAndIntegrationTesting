using System.Collections.Generic;
using System.Threading.Tasks;
using Testavimas_1.Models;

namespace Testavimas_1.Data
{
    public interface IDarbuotojasRepository
    {
        Task<Darbuotojas> Delete(Darbuotojas darbuotojas);
        Task<Darbuotojas> DeleteById(int id);
        Task<List<Darbuotojas>> FindAll();
        Task<Darbuotojas> FindById(int id);
        Task<List<Darbuotojas>> FindByVardas(string vardas);
        Task<Darbuotojas> Save(Darbuotojas darbuotojas);
    }
}