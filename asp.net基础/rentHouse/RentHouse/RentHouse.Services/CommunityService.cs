using System;
using System.Data.Entity;
using System.Linq;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class CommunityService:ICommunityService
    {
        public CommunityDTO[] GetByRegionId(long regionId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<CommunityEntity> commonService = new CommonService<CommunityEntity>(ctx);
                var communityEntities = commonService.GetAll().Include(c => c.Region).AsNoTracking().Where(c => c.RegionId == regionId);
                return communityEntities.ToList().Select(c => new CommunityDTO()
                {
                    Id = c.Id,
                    RegionId = c.RegionId,
                    BuiltYear = c.BuiltYear,
                    CreateDateTime = c.CreateDateTime,
                    Location = c.Location,
                    Name = c.Name,
                    Traffic = c.Traffic
                }).ToArray();
            }
        }
    }
}