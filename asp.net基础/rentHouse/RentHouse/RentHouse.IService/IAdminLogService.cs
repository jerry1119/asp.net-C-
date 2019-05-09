using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentHouse.DTO;

namespace RentHouse.IService
{
    public interface IAdminLogService:IServiceMark
    {
        //插入一条日志,message为要插入的信息
        void AddNewLog(long adminUserId,string message);
        //根据LogID查询出这条log
        AdminLogDTO GetById(long id);
        //todo:做日志搜索等
    }
}
