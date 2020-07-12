using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace suo
{
    class Program
    {
        //乐观锁可以ef写linq语句，自动可以判断(前提是需要在config中指定一列的属性为isRowversion)，而悲观锁则只能写原生sql语句
        static void Main(string[] args)
        {
            using(MyDbContext ctx = new MyDbContext())
            {
                Console.WriteLine("please input your name");
                string bf = Console.ReadLine();
                ctx.Database.Log = (sql) =>
                {
                    Console.WriteLine(sql);
                };
                var g = ctx.Girls.First();
                byte[] rowversion = g.rowver;
                //先判断是否已存在bf
                if (!string.IsNullOrEmpty(g.BF))
                {
                    if (g.BF == bf)
                    {
                        Console.WriteLine("早已是你的人了，还抢啥");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("早已被别人抢走了，来晚了");
                        Console.ReadKey();
                        return;
                    }
                }
                //如果不存在bf，则可以抢
                Console.WriteLine("按任意键开抢");
                Console.ReadKey();
                Thread.Sleep(3000);
                g.BF = bf;  //ef在执行sql语句时会判断 rowversion的值
                try
                {
                    ctx.SaveChanges();
                    Console.WriteLine("抢媳妇成功");
                }
                catch (DbUpdateConcurrencyException)  //捕获这个异常一般是rowversion不一致更新失败
                {

                    Console.WriteLine("抢媳妇失败");
                }
            }
            Console.ReadKey();
        }
        //ef 采用原生sql语句的写法
        static void Main3(string[] args)
        {
            using(MyDbContext ctx = new MyDbContext())
            {
                Console.WriteLine("please input your name");
                string bf = Console.ReadLine();
                var g = ctx.Database.SqlQuery<GirlEntity>("select * from T_girls where id=1").Single();
                byte[] rowversion = g.rowver;
                //先判断是否已存在bf
                if (!string.IsNullOrEmpty(g.BF))
                {
                    if (g.BF==bf)
                    {
                        Console.WriteLine("早已是你的人了，还抢啥");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("早已被别人抢走了，来晚了");
                        Console.ReadKey();
                        return;
                    }
                }
                //如果不存在bf，则可以抢
                Console.WriteLine("按任意键开抢");
                Console.ReadKey();
                Thread.Sleep(3000);
                int affectRow = ctx.Database.ExecuteSqlCommand("update T_Girls set BF={0} where id=1 and rowver={1}", bf, rowversion);
                if (affectRow==0)
                {
                    Console.WriteLine("抢媳妇失败");
                }
                else if(affectRow == 1)
                {
                    Console.WriteLine("抢媳妇成功");
                }
                else
                {
                    Console.WriteLine("未知异常");
                }
            }
            Console.ReadKey();
        }
        //ado.net写的悲观锁
        static void Main2(string[] args)
        {
            Console.WriteLine("请输入你的名字");
            var myname =  Console.ReadLine();
            string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString; 
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        Console.WriteLine("开始查询"); 
                        using (var selectCmd = conn.CreateCommand())
                        {
                            selectCmd.Transaction = tx;
                            //EF 不支持悲观锁，只能写原生 SQL。 一定要在同一个事务中。在查询语句的表名后加上 with (xlock,ROWLOCK)。xlock 表示“排 他锁”，一旦加上排他锁，那么其他人再获得这个锁的话就要等待开锁（事务结束）。 ROWLOCK 为行锁，为锁定查询出来的
                            selectCmd.CommandText = "select * from T_Girls with(xlock,ROWLOCK) where id=1"; 
                            using (var reader = selectCmd.ExecuteReader())
                            {
                                if (!reader.Read()) 
                                {
                                    Console.WriteLine("没有id为1的女孩"); 
                                    return; 
                                }
                                string bf = null; 
                                if (!reader.IsDBNull(reader.GetOrdinal("BF")))
                                { 
                                    bf = reader.GetString(reader.GetOrdinal("BF")); 
                                }
                                if (!string.IsNullOrEmpty(bf))//已经有男朋友 
                                {
                                    if (bf == myname)
                                    {
                                        Console.WriteLine("早已经是我的人了");
                                    }
                                    else
                                    {
                                        Console.WriteLine("早已经被" + bf + "抢走了");
                                    }
                                    Console.ReadKey();
                                    return;
                                }                                 //如果 bf==null，则继续向下抢    
                            }
                            Console.WriteLine("查询完成，开始 update");
                            using (var updateCmd = conn.CreateCommand())
                            {
                                updateCmd.Transaction = tx;
                                updateCmd.CommandText = "Update T_Girls set BF=@bf where id=1";
                                updateCmd.Parameters.Add(new SqlParameter("@bf", myname));
                                updateCmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("结束 Update");
                            Console.WriteLine("按任意键结束事务");
                            Console.ReadKey();
                        }
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        tx.Rollback();
                    }
                }
            }
        }
    }
}
