using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ArchitectureExercise.Core.Entities.Membership;
using ArchitectureExercise.Core.Entities.Membership.ComplexTypes;

namespace ArchitectureExercise.EFData.EFContext.Initializers
{
    public class RecreateAlways : IDatabaseInitializer<MembershipContext>
    {
        #region Implementation of IDatabaseInitializer<in MembershipContext>

        public void InitializeDatabase(MembershipContext context)
        {
            context.Database.Delete();
            context.Database.Create();
            try
            {
                context.SaveChanges();
                Seed(context);
            }
            catch (Exception ex)
            {
                context.Dispose();
                throw;
            }
        }

        #endregion

        #region [Virtual members]

        protected virtual void Seed(MembershipContext context)
        {
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IndexEmail ON Users (Email)");

            var roles = new HashSet<Role>
            {
                new Role() {Name = "User"},
                new Role() {Name = "Admin"}
            };

            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }
            context.SaveChanges();

            var users = new HashSet<User>
            {
                new User()
                {
                    Name = "Artyom",
                    Surname = "Rusak",
                    Password = "123456",
                    Email = "bembi@gmail.com",
                    Address = new Address() {City = "Minsk", Street = "Golubeva"},
                    Roles = new HashSet<Role>() {roles.ElementAt(1)}
                },
                new User()
                {
                    Name = "Egor",
                    Surname = "Rusak",
                    Password = "qwerty",
                    Email = "tramp@mail.ru",
                    Address = new Address() {City = "Minsk", Street = "Kolasa"},
                    Roles = new HashSet<Role>() {roles.ElementAt(0)}
                },
                new User()
                {
                    Name = "Vasya",
                    Surname = "Ivanov",
                    Password = "qwerty123456",
                    Email = "bembi1204@gmail.com",
                    Address = new Address() {City = "Gomel", Street = "Molochnaya"},
                    Roles = new HashSet<Role>() {roles.ElementAt(0), roles.ElementAt(1)}
                }
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }

        #endregion
    }
}
