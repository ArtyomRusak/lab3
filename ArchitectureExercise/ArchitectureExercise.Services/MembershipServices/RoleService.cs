using System;
using System.Linq;
using ArchitectureExercise.Core.Entities.Membership;
using ArchitectureExercise.Core.InterfacesRepositories;
using ArchitectureExercise.EFData.EFContext;
using ArchitectureExercise.EFData.Repositories;

namespace ArchitectureExercise.Services.MembershipServices
{
    public class RoleService : IService<Role>
    {
        #region [Private members]

        private readonly MembershipContext _context;
        private readonly IRepository<Role> _repository;
        private bool _disposed;

        #endregion


        #region [Ctor's]

        public RoleService(MembershipContext context)
        {
            _context = context;
            _repository = new RoleRepository(_context);
        }

        public RoleService()
        {
            _context = new MembershipContext();
            _repository = new RoleRepository(_context);
        }

        #endregion


        #region Implementation of IService<Role>

        public void Create(Role value)
        {
            _repository.Create(value);
        }

        public void Update(Role value)
        {
            _repository.Update(value);
        }

        public void Remove(Role value)
        {
            _repository.Remove(value);
        }

        public Role GetEntityById(int id)
        {
            return _repository.GetEntityById(id);
        }

        public Role Find(Func<Role, bool> predicate)
        {
            return _repository.Find(predicate);
        }

        public IQueryable<Role> All()
        {
            return _repository.All();
        }

        public MembershipContext GetCurrentContext()
        {
            return _context;
        }

        public void Commit()
        {
            _repository.Save();
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            if (!_disposed)
            {
                _repository.Dispose();
                _disposed = true;
            }
        }

        #endregion
    }
}
