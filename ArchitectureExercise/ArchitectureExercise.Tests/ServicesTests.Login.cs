using System;
using ArchitectureExercise.EFData.EFContext;
using ArchitectureExercise.Services.Helpers;
using ArchitectureExercise.Services.MembershipServices;
using FluentAssertions;
using NUnit.Framework;

namespace ArchitectureExercise.Tests
{
    [TestFixture]
    public class ServicesTests
    {
        [Test]
        public void ReturnTrueIfLoginIsSuccessfull()
        {
            var context = new MembershipContext("TestDatabase");
            var service = new UserService(context);
            new Func<AuthentificationResult>(() =>
            {
                var result = service.LoginUser("bembi1204@gmail.com", "qwerty123456");
                service.Dispose();
                return result;
            }).Invoke().Result.Should().Be(true);
        }

        [Test]
        public void ReturnFalseIfLoginIsNonSuccessfull()
        {
            var context = new MembershipContext("TestDatabase");
            var service = new UserService(context);
            new Func<AuthentificationResult>(() =>
            {
                var result = service.LoginUser("bembi1204@gmail.com", "123456");
                service.Dispose();
                return result;
            }).Invoke().Result.Should().Be(false);
        }
    }
}
