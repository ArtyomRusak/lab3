using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.Core.Entities.Membership;

namespace ArchitectureExercise.EFData.EFContext.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(30);
            HasMany(e => e.Users).WithMany(e => e.Roles).Map(m => m.MapLeftKey("RoleId"));
        }
    }
}
