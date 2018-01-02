using Sample_Sqlite.Models.Domeins;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample_Sqlite.Models.Context
{
   public class SampleContext : DbContext , Iunitofwork
    {
        public SampleContext() : base("SQLiteConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            var initializer = new InitialDb(modelBuilder);
            Database.SetInitializer(initializer);
        }
        public DbSet<TblUsers> Users { get; set; }



        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();


            var result = base.SaveChanges();
            return result;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();


            var result = base.SaveChangesAsync(cancellationToken);
            return result;
        }

    }
    public class InitialDb : SQLite.CodeFirst.SqliteCreateDatabaseIfNotExists<SampleContext>
    {
        public InitialDb(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }
        protected override void Seed(SampleContext context)
        {
        }


    }

}
