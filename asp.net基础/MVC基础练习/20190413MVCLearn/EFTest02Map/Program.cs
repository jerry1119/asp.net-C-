using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest02Map
{
    class Program
    {
        static void Main(string[] args)
        {
            sqlPracticeEntities sqlctx = new sqlPracticeEntities();
            subJect sub = new subJect() { subName = "化学" };
            sqlctx.subJects.Add(sub);
            sqlctx.SaveChanges();
            Console.ReadKey();
        }
    }
}
