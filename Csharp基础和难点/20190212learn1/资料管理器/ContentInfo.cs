using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 资料管理器
{
    public class ContentInfo
    {
        public int dId { get; set; }
        public int dTId { get; set; }
        public  string dName { get; set; }
        public string dContent { get; set; }
        public DateTime dInTime { get; set; }
        public DateTime dEditeTime { get; set; }
        public bool dIsDeleted { get; set; }
        public override string ToString()
        {
            return this.dName;
        }
    }
}
