using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Testavimas_1.Models
{
    public class Skambutis : IComparable<Skambutis>, IEquatable<Skambutis>
    {
        public int Id { get; set; }
        [Required]
        public bool Atsiliepta { get; set; }
        [Required]
        public DateTime Laikas { get; set; }
        [Required]
        public int DarbuotojasId { get; set; }
        [Required]
        public int Trukme { get; set; }

        public Darbuotojas Darbuotojas { get; set; }

        public Skambutis(int id, bool atsiliepta, DateTime laikas, int darbuotojasId, int trukme)
        {
            Id = id;
            Atsiliepta = atsiliepta;
            Laikas = laikas;
            DarbuotojasId = darbuotojasId;
            Trukme = trukme;
        }

        public Skambutis()
        {
        }

        public Skambutis(bool atsiliepta, DateTime laikas, int darbuotojasId, int trukme)
        {
            Atsiliepta = atsiliepta;
            Laikas = laikas;
            DarbuotojasId = darbuotojasId;
            Trukme = trukme;
        }

        public int CompareTo(Skambutis skambutis)
        {
            return Id.CompareTo(skambutis.Id);
        }

        public bool Equals(Skambutis skambutis)
        {
            if (this == skambutis)
                return true;
            if (skambutis == null)
                return false;
            if (Id != skambutis.Id)
                return false;
            return true;
        }

        public override string ToString()
        {
            return $"Skambutis: ID {Id} Atsiliepta {Atsiliepta} Laikas {Laikas} Darbuotojo ID {DarbuotojasId} Trukme {Trukme}";
        }

        public override int GetHashCode()
        {
            var prime = 37;
            return HashCode.Combine(Id, prime);
        }
    }
}
