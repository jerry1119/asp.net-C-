using RentHouse.DTO;

namespace RentHouse.IService
{
    public interface IRegionService:IServiceMark
    {
        RegionDTO GetById(long id);
        //获取城市下的区域
        RegionDTO[] GetAll(long cityId);
    }
}