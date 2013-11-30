using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.Core.Entities.Membership;
using ArchitectureExercise.Core.Entities.Membership.ComplexTypes;
using ArchitectureExercise.EFData.EFContext;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //MembershipContext context = new MembershipContext();
            //MembershipContext context1 = new MembershipContext();
            //if (context.Equals(context1))
            //{
            //    Console.WriteLine("Hello");
            //}

            //Console.ReadLine();

            var user = default(User);
            Console.WriteLine(user);

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MembershipContext>());
            //MembershipContext context = new MembershipContext();
            //context.Roles.Add(new Role()
            //{
            //    Name = "Admin",
            //    Users =
            //        new HashSet<User>()
            //        {
            //            new User()
            //            {
            //                Address = new Address() {City = "Minsk", Street = "Hello"},
            //                Name = "Artyom",
            //                Surname = "Rusak",
            //                Password = "123",
            //                Email = "bembi1204@gmail.com"
            //            }
            //        }
            //});
            //context.SaveChanges();
            //context.Dispose();
        }
    }
}
