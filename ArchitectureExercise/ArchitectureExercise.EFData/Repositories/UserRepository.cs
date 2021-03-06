﻿using System;
using System.Data.Entity;
using System.Linq;
using ArchitectureExercise.Core.Entities.Membership;
using ArchitectureExercise.Core.InterfacesRepositories;
using ArchitectureExercise.EFData.EFContext;
using ArchitectureExercise.EFData.Repositories.Helpers;

namespace ArchitectureExercise.EFData.Repositories
{
    public class UserRepository : IRepository<User>
    {
        #region [Private members]

        private readonly MembershipContext _context;
        private readonly DbSet<User> _users;
        private bool _disposed;

        #endregion


        #region [Ctor's]

        public UserRepository(MembershipContext context)
        {
            _context = context;
            _users = _context.Set<User>();
        }

        public UserRepository()
        {
            _context = new MembershipContext();
            _users = _context.Set<User>();
        }

        #endregion


        #region Implementation of IRepository<User>

        public void Create(User value)
        {
            _users.Add(value);
        }

        public void Update(User value)
        {
            _users.Attach(value);
            _context.Entry(value).State = EntityState.Modified;
        }

        public void Remove(User value)
        {
            _users.Remove(value);
        }

        public User GetEntityById(int id)
        {
            return _users.SingleOrDefault(e => e.Id == id);
        }

        public User Find(Func<User, bool> predicate)
        {
            RepositoryHelper<User>.CheckPredicate(predicate, "predicate");
            return _users.SingleOrDefault(predicate);
        }

        public IQueryable<User> All()
        {
            return _users.AsQueryable();
        }

        public IQueryable<User> Filter(Func<User, bool> predicate)
        {
            RepositoryHelper<User>.CheckPredicate(predicate, "predicate");
            return _users.Where(predicate).AsQueryable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
                _disposed = true;
            }
        }

        #endregion
    }
}
