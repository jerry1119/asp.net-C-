using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest01.EFConfig
{
    class PersonConfig:EntityTypeConfiguration<Person>
    {
        PersonConfig()
        {
            this.ToTable("T_Persons");  //这种是FluentApi的方式，等价于在实体类上s加标记 [Table("T_Persons")]
            this.HasMany(p => p.Cars).WithRequired();

        }
    }
}
