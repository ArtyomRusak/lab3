using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.Core.Entities.Membership;
using ArchitectureExercise.Core.InterfacesRepositories;
using ArchitectureExercise.EFData.EFContext;
using ArchitectureExercise.EFData.Repositories.Helpers;

namespace ArchitectureExercise.EFData.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        #region [Private members]

        private readonly DbContext _context;
        private readonly DbSet<Role> _roles;

        #endregion


        #region [Ctor's]

        public RoleRepository(DbContext context)
        {
            _context = context;
            _roles = _context.Set<Role>();
        }

        public RoleRepository()
        {
            _context = new MembershipContext();
            _roles = _context.Set<Role>();
        }

        #endregion


        #region Implementation of IRepository<Role>

        public void Create(Role value)
        {
            _roles.Add(value);
        }

        public void Update(Role value)
        {
            _roles.Attach(value);
            _context.Entry(value).State = EntityState.Modified;
        }

        public void Delete(Role value)
        {
            _roles.Remove(value);
        }

        public Role GetEntityById(int id)
        {
            return _roles.SingleOrDefault(e => e.Id == id);
        }

        public Role Find(Func<Role, bool> predicate)
        {
            RepositoryHelper<Role>.CheckPredicate(predicate, "predicate");
            return _roles.SingleOrDefault(predicate);
        }

        public IQueryable<Role> All()
        {
            return _roles;
        }

        public IQueryable<Role> Filter(Func<Role, bool> predicate)
        {
            RepositoryHelper<Role>.CheckPredicate(predicate, "predicate");
            return _roles.Where(predicate).AsQueryable();
        }

        #endregion

    }
}
