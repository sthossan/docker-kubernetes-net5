using System.Threading.Tasks;

namespace Models.DataContext
{
    public interface IEfDbContext
    {
        #region DBSet Property
        
        //public DbSet<Profile> Profiles { get; set; }
        
        #endregion

        #region Transactions
        void BeginTran();
        void CommitTran();
        void RollbackTran();
        Task BeginTranAsync();
        Task CommitTranAsync();
        Task RollbackTranAsync();
        #endregion

        /// <summary>
        /// This is to generate json by stored procedure.
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        Task<string> SqlQueryToGetJson(string sqlQuery);
    }
}
