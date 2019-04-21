using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest01.EFConfig
{
    class CarConfig:EntityTypeConfiguration<Car>
    {
        CarConfig()
        {
            this.ToTable("T_Cars");
        }
    }
}
