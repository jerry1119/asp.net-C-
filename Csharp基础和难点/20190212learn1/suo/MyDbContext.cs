using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace suo
{
    class MyDbContext:DbContext
    {
        public MyDbContext() : base("name=ConnStr")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Assembly asm = Assembly.GetExecutingAssembly();
            modelBuilder.Configurations.AddFromAssembly(asm);
        }
        public DbSet<GirlEntity> Girls { get; set; }
    }
}
