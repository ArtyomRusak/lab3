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
    [TestFixture]
    public partial class RepositoriesTests
    {
        [Test]
        public void ShouldAddRoleToDatabase()
        {
            MembershipContext context = new MembershipContext("TestDatabase");
            IRepository<Role> repository = new RoleRepository(context);
            var role = new Role() {Name = "New Role"};
            repository.Create(role);
            repository.Save();

            var roleObj = repository.GetEntityById(role.Id);

            repository.Dispose();

            roleObj.ShouldBeEquivalentTo(role);
        }

        [Test]
        public void ShouldReadRoleFromDatabase()
        {
            MembershipContext context = new MembershipContext("TestDatabase");
            IRepository<Role> repository = new RoleRepository(context); 
            var role = repository.Find(e => e.Name == "User");
            repository.Dispose();
            role.Should().NotBeNull();
        }

        [Test]
        public void ShouldUpdateRoleFromDatabase()
        {
            MembershipContext context = new MembershipContext("TestDatabase");
            IRepository<Role> repository = new RoleRepository(context);
            var role = repository.GetEntityById(1);
            role.Name = "New name for entity";
            repository.Save();
            var newRole = repository.GetEntityById(1);
            repository.Dispose();

            role.Should().Be(newRole);
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfPredicateNullFindRole()
        {
            IRepository<Role> repository = new RoleRepository(new MembershipContext("TestDatabase"));
            new Action(() =>
            {
                repository.Find(null);
                repository.Dispose();
            }).ShouldThrow<ArgumentException>()
                .Where(e => e.ParamName.Equals("predicate"));
        }

        [Test]
        public void ShouldThrowArgumentExceptionIfPredicateNullFilterRole()
        {
            IRepository<Role> repository = new RoleRepository(new MembershipContext("TestDatabase"));
            new Action(() =>
            {
                repository.Filter(null);
                repository.Dispose();
            }).ShouldThrow<ArgumentException>()
                .Where(e => e.ParamName.Equals("predicate"));
        }

        [Test]
        public void ShouldNotThrowArgumentExceptionIfPredicateNullFindRole()
        {
            IRepository<Role> repository = new RoleRepository(new MembershipContext("TestDatabase"));
            new Action(() =>
            {
                repository.Find(e => e.Name == "123");
                repository.Dispose();
            }).ShouldNotThrow<ArgumentException>();
        }

        [Test]
        public void ShouldNotThrowArgumentExceptionIfPredicateNullFilterRole()
        {
            IRepository<Role> repository = new RoleRepository(new MembershipContext("TestDatabase"));
            new Action(() =>
            {
                repository.Filter(e => e.Name == "123");
                repository.Dispose();
            }).ShouldNotThrow<ArgumentException>();
        }
    }
}
