using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFTest01
{
    public class PersonContext:DbContext
    {
        public PersonContext() : base("name=Connstr")
        {
            //禁用每次EF自动执行sql的时候执行MigrationHistory（这个是用来创建数据库表的，没有必要）
            //System.Data.Entity.Database.SetInitializer<PersonContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            //代表从这句话所在的程序集加载所有的继承自EntityTypeConfiguration为模型配置类。
        

            //modelBuilder.Entity<Person>().ToTable("T_Person"); 其实也可以直接在这里写指定那个类对应哪一张表，但是表太多的话写这里不好，太多了，还是分别写在config里面，另外，如果表名和类名一样的话，可以直接不写
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
