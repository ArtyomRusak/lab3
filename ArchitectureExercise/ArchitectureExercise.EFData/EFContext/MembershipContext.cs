using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.Core.Entities.Membership;
using ArchitectureExercise.Core.Entities.Membership.ComplexTypes;
using ArchitectureExercise.EFData.EFContext.Mapping;

namespace ArchitectureExercise.EFData.EFContext
{
    public class MembershipContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        #region Overrides of DbContext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Address>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
