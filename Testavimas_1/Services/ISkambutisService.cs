using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testavimas_1.Models;

namespace Testavimas_1.Services
{
    public interface ISkambutisService
    {
        Task<Skambutis> DeleteById(int id);
        Task<List<Skambutis>> GetAll();
        Task<DateTime> GetTimeById(int id);
        Task<Skambutis> AddOrUpdate(Skambutis skambutis);
        Task<Skambutis> GetById(int id);
    }
}