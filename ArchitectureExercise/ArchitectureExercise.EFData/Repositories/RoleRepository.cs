﻿using System;
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

        private readonly MembershipContext _context;
        private readonly DbSet<Role> _roles;
        private bool _disposed;

        #endregion


        #region [Ctor's]

        public RoleRepository(MembershipContext context)
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

        public void Remove(Role value)
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
