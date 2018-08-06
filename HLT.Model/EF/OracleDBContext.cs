using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HLT.Model.Entity;

namespace HLT.Model.EF
{
    public class OracleDBContext : DbContext
    {
        public OracleDBContext() : base("name=Oracle")
        {
            Database.SetInitializer<OracleDBContext>(new DropCreateDatabaseIfModelChanges<OracleDBContext>());
        }

        public OracleDBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TEST");//修改默认表结构前缀
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//设置表名字不以负数形式创建表
        }

        public DbSet<Test> Tests { get; set; }
    }
}
