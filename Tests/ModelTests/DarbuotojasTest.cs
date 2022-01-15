using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Models;
using Xunit;

namespace Testavimas_1.Tests
{
    public class DarbuotojasTest
    {
        [Fact]
        public void TestCompareTo()
        {
            var d1 = new Darbuotojas(1, "Antanas", "Vilnius");
            var d2 = new Darbuotojas(1, "Antanas", "Vilnius");
            Assert.Equal(0, d1.CompareTo(d2));
        }

        [Fact]
        public void TestEquals()
        {
            var d1 = new Darbuotojas(1, "Antanas", "Vilnius");
            var d2 = new Darbuotojas(1, "Antanas", "Vilnius");
            Assert.True(d1.Equals(d2));
        }

        [Fact]
        public void TestHashCodes()
        {
            var d1 = new Darbuotojas(1, "Antanas", "Vilnius");
            var d2 = new Darbuotojas(1, "Antanas", "Vilnius");
            Assert.Equal(d1.GetHashCode(), d2.GetHashCode());
        }
    }
}
