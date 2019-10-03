using RentHouse.DTO;

namespace RentHouse.IService
{
    public interface ICommunityService:IServiceMark
    {
        //获取区域RegionId下所有小区
        CommunityDTO[] GetByRegionId(long regionId);
    }
}