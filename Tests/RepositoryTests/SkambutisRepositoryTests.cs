using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testavimas_1.Data;
using Testavimas_1.Models;
using Xunit;

namespace Tests.RepositoryTests
{
    public class SkambutisRepositoryTests
    {

        [Fact]
        public async Task TestSave()
        {
            var options = new DbContextOptionsBuilder<TestavimasContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new TestavimasContext(options))
            {
                ISkambutisRepository repository = new SkambutisRepository(context);
                var skambutis = new Skambutis();

                await repository.Save(skambutis);

                Assert.Equal(1, context.Skambuciai.Count());
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
                // reikia sukurti ir skambuciu darbuotojus, nes FindAll kai grazina includina ir skambucio darbuotoja
                var s1 = new Skambutis(); s1.Darbuotojas = new Darbuotojas();
                var s2 = new Skambutis(); s2.Darbuotojas = new Darbuotojas();
                var s3 = new Skambutis(); s3.Darbuotojas = new Darbuotojas();
                context.Skambuciai.Add(s1);
                context.Skambuciai.Add(s2);
                context.Skambuciai.Add(s3);

                context.SaveChanges();

                ISkambutisRepository repository = new SkambutisRepository(context);

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

                context.Skambuciai.Add(new Skambutis());
                context.Skambuciai.Add(new Skambutis());
                context.Skambuciai.Add(new Skambutis());

                context.SaveChanges();

                ISkambutisRepository repository = new SkambutisRepository(context);

                var firstId = context.Skambuciai.First().Id;

                await repository.DeleteById(firstId);

                Assert.Equal(2, context.Skambuciai.Count());
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
                context.Skambuciai.Add(new Skambutis());
                context.Skambuciai.Add(new Skambutis());
                context.Skambuciai.Add(new Skambutis());

                context.SaveChanges();

                ISkambutisRepository repository = new SkambutisRepository(context);

                var firstSkambutis = context.Skambuciai.First();

                await repository.Delete(firstSkambutis);

                Assert.Equal(2, context.Skambuciai.Count());
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
                var s1 = new Skambutis(); s1.Darbuotojas = new Darbuotojas();
                var s2 = new Skambutis(); s2.Darbuotojas = new Darbuotojas();
                var s3 = new Skambutis(); s3.Darbuotojas = new Darbuotojas();
                context.Skambuciai.Add(s1);
                context.Skambuciai.Add(s2);
                context.Skambuciai.Add(s3);

                context.SaveChanges();

                int firstId = context.Skambuciai.First().Id;

                ISkambutisRepository repository = new SkambutisRepository(context);

                var result = await repository.FindById(firstId);

                Assert.NotNull(result);
            }
        }
    }
}
