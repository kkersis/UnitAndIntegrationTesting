using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testavimas_1.Models;
using Xunit;

namespace Testavimas_1.Tests
{
    public class SkambutisTest
    {
        [Fact]
        public void TestCompareTo()
        {
            var s1 = new Skambutis(1, true, DateTime.Now, 1, 123);
            var s2 = new Skambutis(1, true, DateTime.Now, 1, 123);
            Assert.Equal(0, s1.CompareTo(s2));
        }

        [Fact]
        public void TestEquals()
        {
            var s1 = new Skambutis(1, true, DateTime.Now, 1, 123);
            var s2 = new Skambutis(1, true, DateTime.Now, 1, 123);
            Assert.True(s1.Equals(s2));
        }

        [Fact]
        public void TestHashCodes()
        {
            var s1 = new Skambutis(1, true, DateTime.Now, 1, 123);
            var s2 = new Skambutis(1, true, DateTime.Now, 1, 123);
            Assert.Equal(s1.GetHashCode(), s2.GetHashCode());
        }
    }
}
