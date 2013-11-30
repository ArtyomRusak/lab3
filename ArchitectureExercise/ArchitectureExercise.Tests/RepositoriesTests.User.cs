using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.Core.Entities.Membership;
using ArchitectureExercise.Core.Entities.Membership.ComplexTypes;
using ArchitectureExercise.Core.InterfacesRepositories;
using ArchitectureExercise.EFData.EFContext;
using ArchitectureExercise.EFData.Repositories;
using FluentAssertions;
using NUnit.Framework;

namespace ArchitectureExercise.Tests
{
    public partial class RepositoriesTests
    {
        [Test]
        public void ShouldAddUserToDatabase()
        {
            MembershipContext context = new MembershipContext("TestDatabase");
            IRepository<User> repository = new UserRepository(context);
            var user = new User()
            {
                Name = "Peter",
                Surname = "Davidson",
                Password = "123",
                Address = new Address()
                {
                    City = "Minsk",
                    Street = "Golubeva street"
                },
                Roles = { context.Roles.Where(e => e.Name == "Admin").Select(w => w).SingleOrDefault() }
            };
            repository.Create(user);
            repository.Save();

            var userObj = repository.GetEntityById(user.Id);

            repository.Dispose();

            userObj.ShouldBeEquivalentTo(user);
        }

        [Test]
        public void ShouldReadUserFromDatabase()
        {
            MembershipContext context = new MembershipContext("TestDatabase");
            IRepository<User> repository = new UserRepository(context);
            var user = repository.Find(e => e.Name == "Artyom");
            repository.Dispose();
            user.Should().NotBeNull();
        }

        [Test]
        public void ShouldUpdateUserFromDatabase()
        {
            MembershipContext context = new MembershipContext("TestDatabase");
            IRepository<User> repository = new UserRepository(context);
            var user = repository.GetEntityById(3);
            user.Name = "New name for entity";
            repository.Save();
            var newUser = repository.GetEntityById(3);
            repository.Dispose();

            user.Should().Be(newUser);
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfPredicateNullFindUser()
        {
            IRepository<User> repository = new UserRepository(new MembershipContext("TestDatabase"));
            new Action(() =>
            {
                repository.Find(null);
                repository.Dispose();
            }).ShouldThrow<ArgumentException>()
                .Where(e => e.ParamName.Equals("predicate"));
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfPredicateNullFilterUser()
        {
            IRepository<User> repository = new UserRepository(new MembershipContext("TestDatabase"));
            new Action(() =>
            {
                repository.Filter(null);
                repository.Dispose();
            }).ShouldThrow<ArgumentException>()
                .Where(e => e.ParamName.Equals("predicate"));
        }

        [Test]
        public void ShouldNotThrowArgumentExceptionIfPredicateNullFindUser()
        {
            IRepository<User> repository = new UserRepository(new MembershipContext("TestDatabase"));
            new Action(() =>
            {
                repository.Find(e => e.Name == "123");
                repository.Dispose();
            }).ShouldNotThrow<ArgumentException>();
        }

        [Test]
        public void ShouldNotThrowArgumentExceptionIfPredicateNullFilterUser()
        {
            IRepository<User> repository = new UserRepository(new MembershipContext("TestDatabase"));
            new Action(() =>
            {
                repository.Filter(e => e.Name == "123");
                repository.Dispose();
            }).ShouldNotThrow<ArgumentException>();
        }
    }
}
