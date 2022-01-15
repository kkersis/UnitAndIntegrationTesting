using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Testavimas_1.Data;
using Testavimas_1.Models;
using Xunit;

namespace Tests.RepositoryTests
{
    public class DarbuotojasRepositoryTests
    {

        [Fact]
        public async Task TestSave()
        {
            var options = new DbContextOptionsBuilder<TestavimasContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestavimasContext(options))
            {
                IDarbuotojasRepository repository = new DarbuotojasRepository(context);
                var darbuotojas = new Darbuotojas();

                await repository.Save(darbuotojas);
    
                Assert.Equal(1, context.Darbuotojai.Count());
            }
        }

        [Fact]
        public async Task TestDelete()
        {
            var options = new DbContextOptionsBuilder<TestavimasContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestavimasContext(options))
            {
                context.Darbuotojai.Add(new Darbuotojas());
                context.Darbuotojai.Add(new Darbuotojas());
                context.Darbuotojai.Add(new Darbuotojas());

                context.SaveChanges();

                IDarbuotojasRepository repository = new DarbuotojasRepository(context);

                var firstDarbuotojas = context.Darbuotojai.First();

                await repository.Delete(firstDarbuotojas);

                Assert.Equal(2, context.Darbuotojai.Count());
            }
        }

        [Fact]
        public async Task TestFindById()
        {
            var options = new DbContextOptionsBuilder<TestavimasContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestavimasContext(options))
            {
                context.Darbuotojai.Add(new Darbuotojas());
                context.Darbuotojai.Add(new Darbuotojas());
                context.Darbuotojai.Add(new Darbuotojas());

                context.SaveChanges();

                int firstId = context.Darbuotojai.First().Id;

                IDarbuotojasRepository repository = new DarbuotojasRepository(context);

                var result = await repository.FindById(firstId);

                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task TestFindAll()
        {
            var options = new DbContextOptionsBuilder<TestavimasContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestavimasContext(options))
            {
                context.Darbuotojai.Add(new Darbuotojas());
                context.Darbuotojai.Add(new Darbuotojas());
                context.Darbuotojai.Add(new Darbuotojas());

                context.SaveChanges();

                IDarbuotojasRepository repository = new DarbuotojasRepository(context);
                var darbuotojas = new Darbuotojas();

                var result = await repository.FindAll();

                Assert.Equal(3, result.Count);
            }
        }

        [Fact]
        public async Task TestDeleteById()
        {
            var options = new DbContextOptionsBuilder<TestavimasContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestavimasContext(options))
            {
                context.Darbuotojai.Add(new Darbuotojas());
                context.Darbuotojai.Add(new Darbuotojas());
                context.Darbuotojai.Add(new Darbuotojas());

                context.SaveChanges();

                IDarbuotojasRepository repository = new DarbuotojasRepository(context);
                var darbuotojas = new Darbuotojas();

                var firstId = context.Darbuotojai.First().Id;

                await repository.DeleteById(firstId);

                Assert.Equal(2, context.Darbuotojai.Count());
            }
        }

        [Fact]
        public async Task TestFindByVardas()
        {
            var options = new DbContextOptionsBuilder<TestavimasContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            using (var context = new TestavimasContext(options))
            {
                context.Darbuotojai.Add(new Darbuotojas("Vilius", "Kaunas"));
                context.Darbuotojai.Add(new Darbuotojas("Andrius", "Vilnius"));
                context.Darbuotojai.Add(new Darbuotojas("Petras", "Kedainiai"));

                context.SaveChanges();

                IDarbuotojasRepository repository = new DarbuotojasRepository(context);
                var darbuotojas = new Darbuotojas();

                var result = await repository.FindByVardas("Andrius");

                Assert.Equal("Vilnius", result.First().Miestas);
            }
        }
    }
}
