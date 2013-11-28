using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.Core.Entities.Membership;

namespace ArchitectureExercise.EFData.EFContext.Mapping
{
    internal class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(30);
            Property(e => e.Surname).IsRequired().HasMaxLength(40);
            Property(e => e.Address.City).IsRequired().HasMaxLength(30);
            Property(e => e.Address.Street).IsRequired().HasMaxLength(40);
            Property(e => e.Address.NumberOfHouse).IsRequired();
            HasMany(e => e.Roles).WithMany(e => e.Users);
        }
    }
}
