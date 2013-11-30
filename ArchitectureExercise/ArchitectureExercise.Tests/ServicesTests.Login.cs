using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.EFData.EFContext;
using ArchitectureExercise.Services;
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
            MembershipContext context = new MembershipContext("TestDatabase");
            UserService service = new UserService(context);
            new Func<bool>(() =>
            {
                var result = service.LoginUser("bembi1204@gmail.com", "qwerty123456");
                service.Dispose();
                return result;
            }).Invoke().Should().Be(true);
        }

        [Test]
        public void ReturnFalseIfLoginIsNonSuccessfull()
        {
            MembershipContext context = new MembershipContext("TestDatabase");
            UserService service = new UserService(context);
            new Func<bool>(() =>
            {
                var result = service.LoginUser("bembi1204@gmail.com", "123456");
                service.Dispose();
                return result;
            }).Invoke().Should().Be(false);
        }
    }
}
