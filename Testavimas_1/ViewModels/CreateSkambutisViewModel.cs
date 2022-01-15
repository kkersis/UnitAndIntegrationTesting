using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Models;

namespace Testavimas_1.ViewModels
{
    public class CreateSkambutisViewModel
    {
        public Skambutis Skambutis { get; set; }
        public List<Darbuotojas> Darbuotojai { get; set; }
    }
}
