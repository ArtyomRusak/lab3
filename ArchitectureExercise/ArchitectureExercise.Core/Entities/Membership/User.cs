using System.Collections.Generic;
using ArchitectureExercise.Core.Entities.Membership.ComplexTypes;

namespace ArchitectureExercise.Core.Entities.Membership
{
    public class User : Entity
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
