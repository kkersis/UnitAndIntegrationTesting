using System.Collections.Generic;
using System.Threading.Tasks;
using Testavimas_1.Models;

namespace Testavimas_1.Data
{
    public interface ISkambutisRepository
    {
        Task<Skambutis> Delete(Skambutis skambutis);
        Task<Skambutis> DeleteById(int id);
        Task<List<Skambutis>> FindAll();
        Task<Skambutis> FindById(int id);
        Task<Skambutis> Save(Skambutis skambutis);
    }
}