using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Testavimas_1.Models
{
    public class Darbuotojas : IComparable<Darbuotojas>, IEquatable<Darbuotojas>
    {
        public int Id { get; set; }
        [Required]
        public string Vardas { get; set; }
        [Required]
        public string Miestas { get; set; }

        public Darbuotojas(int id, string vardas, string miestas)
        {
            Id = id;
            Vardas = vardas;
            Miestas = miestas;
        }

        public Darbuotojas(string vardas, string miestas)
        {
            Vardas = vardas;
            Miestas = miestas;
        }

        public Darbuotojas()
        {
        }

        public bool Equals(Darbuotojas darbuotojas)
        {
            if (this == darbuotojas)
                return true;
            if (darbuotojas == null)
                return false;
            if (Id != darbuotojas.Id)
                return false;
            return true;
        }

        public int CompareTo(Darbuotojas darbuotojas)
        {
            return Id.CompareTo(darbuotojas.Id);
        }

        public override string ToString()
        {
            return $"Darbuotojas: ID {Id} Vardas {Vardas} Miestas {Miestas}";
        }
        public override int GetHashCode()
        {
            var prime = 37;
            return HashCode.Combine(Id, prime);
        }
    }
}
