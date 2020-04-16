using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebUI.DBEntities
{
    public class ArmyContext : DbContext
    {
        public ArmyContext() : base("ArmyContext")
        {

        }

        public DbSet<Type> Types { get; set; }
        public DbSet<Army> Armys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class ArmyInitializer : DropCreateDatabaseIfModelChanges<ArmyContext>
    {
        protected override void Seed(ArmyContext context)
        {
            var armys = new List<Army>
            {
                new Army { Name = "Spain" },
                new Army { Name = "German"},
                new Army { Name = "Japan"}
            };

            armys.ForEach(s => context.Armys.Add(s));
            context.SaveChanges();

            var types = new List<Type>
            {
                new Type { Name = "Horse", Count = 3000, ArmyId = 1},
                new Type { Name = "Sword", Count = 10000, ArmyId = 2},
                new Type { Name = "Bow", Count = 5000, ArmyId = 3}
            };

            types.ForEach(s => context.Types.Add(s));
            context.SaveChanges();
        }
    }
}
