using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentHouse.DTO;

namespace RentHouse.IService
{

    public interface ICityService:IServiceMark
    {
        /// <summary>
        /// 新增城市
        /// </summary>
        /// <param name="cityName">城市名字</param>
        /// <returns>新增城市的ID</returns>
       long AddNew(string cityName);
        //根据城市ID获得城市
        CityDTO GetById(long id);
        //获取所有城市
        CityDTO[] GetAll();
    }
}
