using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    //开 发 通 用 的 CommonService ，提供 GetAll() 、 MarkDeleted() 、 GetTotalCount 、GetPagedData()、GetById()等通用的方法。
    class CommonService<T> where T :BaseEntity
    {
        private  RhDbContext _dbContext;//不自己维护MyDbContext而是由调用者传递，因为调用者可以要执行很多操作，由调用者决定什么时候销毁。
        //注意：构造函数要传参数的话一定是public的 。。
        public CommonService(RhDbContext ctx)
        {
            this._dbContext = ctx;
        }

        public IQueryable<T> GetAll()
        {
           return _dbContext.Set<T>().Where(t => t.IsDeleted == false);
        }
        //获取分页数据，去掉软删除的部分
        public IQueryable<T> GetPageData(int start,int count)
        {
            return GetAll().Skip(start).Take(count);
        }
        //获取总条数
        public long GetTotalCount()
        {
            return GetAll().LongCount();
        }

        public T GetById(long id)
        {
            return GetAll().SingleOrDefault(t => t.Id == id);
        }

        public int MarkDeleted(long id)
        {
            T en = GetById(id);
            if (en!=null)
            {
                en.IsDeleted = true;
                return _dbContext.SaveChanges();
            }
            else
            {
                return -1;
            }
        }
    }
}
