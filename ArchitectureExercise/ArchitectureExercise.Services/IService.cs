using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitectureExercise.Core.Entities;
using ArchitectureExercise.EFData.EFContext;

namespace ArchitectureExercise.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : Entity
    {
        void Create(TEntity value);
        void Update(TEntity value);
        void Remove(TEntity value);
        TEntity GetEntityById(int id);
        TEntity Find(Func<TEntity, bool> predicate);
        IQueryable<TEntity> All();
        MembershipContext GetCurrentContext();
        void Commit();
    }
}
