using System;
using ArchitectureExercise.Core.Entities;

namespace ArchitectureExercise.EFData.Repositories.Helpers
{
    static class RepositoryHelper<TEntity> where TEntity : Entity
    {
        #region [Constants]

        private const string WrongPredicateMessage = "Wrong predicate";

        #endregion


        #region [RepositoryHelper members]

        public static void CheckPredicate(Func<TEntity, bool> predicate, string parameterName)
        {
            if (predicate == null)
            {
                throw new ArgumentException(WrongPredicateMessage, parameterName);
            }
        }

        #endregion

    }
}
