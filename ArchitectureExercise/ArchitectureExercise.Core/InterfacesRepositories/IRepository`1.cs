﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using ArchitectureExercise.Core.Entities;

namespace ArchitectureExercise.Core.InterfacesRepositories
{
    public interface IRepository<TEntity> : IRepository, IDisposable where TEntity : Entity
    {
        void Create(TEntity value);
        void Update(TEntity value);
        void Remove(TEntity value);
        TEntity GetEntityById(int id);
        TEntity Find(Func<TEntity, bool> predicate);
        IQueryable<TEntity> All();
        IQueryable<TEntity> Filter(Func<TEntity, bool> predicate);
        void Save();
    }
}
