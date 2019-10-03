using System;
using System.Linq;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class RegionService : IRegionService
    {
        public RegionDTO[] GetAll(long cityId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RegionEntity> cs= new CommonService<RegionEntity>(ctx);
                return cs.GetAll().Where(a => a.CityId == cityId).ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public RegionDTO GetById(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RegionEntity> cs= new CommonService<RegionEntity>(ctx);
                //return Entity2DTO(cs.GetById(id));
                var region = cs.GetById(id);
                return region == null ? null : Entity2DTO(region);
            }
        }

        public RegionDTO Entity2DTO(RegionEntity regionEntity)
        {
            return new RegionDTO()
            {
                Id = regionEntity.Id,
                CityId = regionEntity.CityId,
                CityName = regionEntity.City.Name,
                CreateDateTime = regionEntity.CreateDateTime,
                Name = regionEntity.Name
            };
        }
    }
}