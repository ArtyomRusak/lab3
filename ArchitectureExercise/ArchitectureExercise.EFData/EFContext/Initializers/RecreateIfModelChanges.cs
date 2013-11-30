using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ArchitectureExercise.EFData.EFContext.Initializers
{
    public class RecreateIfModelChanges : IDatabaseInitializer<MembershipContext>
    {
        #region Implementation of IDatabaseInitializer<in MembershipContext>

        public void InitializeDatabase(MembershipContext context)
        {
            bool databaseExists;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                databaseExists = context.Database.Exists();
            }
            if (databaseExists)
            {
                if (context.Database.CompatibleWithModel(true))
                {
                    return;
                }
                context.Database.Delete();
            }
            context.Database.Create();
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                context.Dispose();
                throw;
            }
        }

        #endregion
    }
}
