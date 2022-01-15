using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Models;

namespace Testavimas_1.Data
{
    public class TestavimasContext : DbContext
    {
        public TestavimasContext(DbContextOptions<TestavimasContext> options) : base(options)
        {
        }

        public DbSet<Darbuotojas> Darbuotojai { get; set; }
        public DbSet<Skambutis> Skambuciai { get; set; }
    }
}
