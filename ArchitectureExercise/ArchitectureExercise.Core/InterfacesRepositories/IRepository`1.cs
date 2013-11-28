using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using ArchitectureExercise.Core.Entities;
using ArchitectureExercise.Core.InterfacesOfRepositories;

namespace ArchitectureExercise.Core.InterfacesRepositories
{
    public interface IRepository<TEntity> : IRepository where TEntity : Entity
    {
        void Create(TEntity value);
        void Update(TEntity value);
        void Delete(TEntity value);
        TEntity GetEntityById(int id);
        TEntity Find(Func<TEntity, bool> predicate);
        IQueryable<TEntity> All();
        IQueryable<TEntity> Filter(Func<TEntity, bool> predicate);
    }
}
