using System;
using System.Collections.Generic;
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


            MembershipContext context = new MembershipContext();
            context.Roles.Add(new Role()
            {
                Name = "Admin",
                Users =
                    new HashSet<User>()
                    {
                        new User()
                        {
                            Address = new Address() {City = "Minsk", Street = "Hello"},
                            Name = "Artyom",
                            Surname = "Rusak"
                        }
                    }
            });
            context.SaveChanges();
            context.Dispose();
        }
    }
}
