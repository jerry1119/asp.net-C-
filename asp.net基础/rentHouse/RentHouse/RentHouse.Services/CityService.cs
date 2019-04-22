using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class CityService:ICityService
    {
        public long AddNew(string cityName)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<CityEntity> baseService = new CommonService<CityEntity>(ctx);
                //判断是否存在任何一条数据满足 c.Name == cityName
                //即存在这样一个名字的城市
                //如果只是判断“是否存在”，那么用Any效率比Where().count()效率
                if (baseService.GetAll().Any(c => c.Name == cityName))
                {
                    throw new ArgumentException("城市已存在");
                }
                CityEntity city = new CityEntity
                {
                    Name = cityName
                };
                ctx.Cities.Add(city);
                ctx.SaveChanges();
                return city.Id;
            }
        }
    }
}
