using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suo
{
    class GirlConfig:EntityTypeConfiguration<GirlEntity>
    {
        public GirlConfig()
        {
            ToTable("T_Girls");
            Property(g => g.rowver).IsRowVersion();
        }
    }
}
