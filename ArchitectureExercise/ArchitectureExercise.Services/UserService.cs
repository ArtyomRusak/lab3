using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.Core.Entities.Membership;
using ArchitectureExercise.Core.InterfacesRepositories;
using ArchitectureExercise.EFData.EFContext;
using ArchitectureExercise.EFData.Repositories;

namespace ArchitectureExercise.Services
{
    public class UserService : IService<User>
    {
        #region [Private members]

        private readonly MembershipContext _context;
        private readonly IRepository<User> _repository;
        private bool _disposed;

        #endregion


        #region [Ctor's]

        public UserService(MembershipContext context)
        {
            _context = context;
            _repository = new UserRepository(_context);
        }

        public UserService()
        {
            _context = new MembershipContext();
            _repository = new UserRepository(_context);
        }

        #endregion


        #region Implementation of IService<User>

        public void Create(User value)
        {
            _repository.Create(value);
        }

        public void Update(User value)
        {
            _repository.Update(value);
        }

        public void Remove(User value)
        {
            _repository.Remove(value);
        }

        public User GetEntityById(int id)
        {
            return _repository.GetEntityById(id);
        }

        public User Find(Func<User, bool> predicate)
        {
            return _repository.Find(predicate);
        }

        public IQueryable<User> All()
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

        #region [UserService's members]

        public User GetUserByEmail(string email)
        {
            return _repository.All().SingleOrDefault(e => e.Email==email);
        }

        public bool LoginUser(string email, string password)
        {
            var user = GetUserByEmail(email);
            return user != null && user.Password == password;
        }

        #endregion
    }
}
