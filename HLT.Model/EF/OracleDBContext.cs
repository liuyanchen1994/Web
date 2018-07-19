using System.Data.Entity;

namespace HLT.Model.EF
{
    public class OracleDBContext : DbContext, IUnitOfWork
    {
        public OracleDBContext() : base("Oracle")
        {

        }

        public OracleDBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}
