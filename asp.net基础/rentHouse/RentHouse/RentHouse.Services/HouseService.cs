using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class HouseService : IHouseService
    {
        public HouseDTO[] GetAll()
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                //为了避免延迟加载，所以直接include 在读取本表时把指定的外键表信息也读出来
                return cs.GetAll().Include(a => a.Community).Include(a => a.Community.Region)
                    .Include(a => a.Community.Region.City).Include(a => a.Attachments).Include(a => a.HousePics).Include(a => a.DecorateStatus)
                    .Include(a => a.Status).Include(a => a.RoomType).Include(a => a.Type).AsNoTracking()
                    .ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        private HouseDTO Entity2DTO(HouseEntity entity)
        {
            return new HouseDTO()
            {
                Address = entity.Address,
                Area = entity.Area,
                AttachmentIds = entity.Attachments.Select(a => a.Id).ToArray(),
                CheckInDateTime = entity.CheckInDateTime,
                CityId = entity.Community.Region.CityId,
                CityName = entity.Community.Region.City.Name,
                CommunityBuiltYear = entity.Community.BuiltYear,
                CommunityId = entity.CommunityId,
                CommunityLocation = entity.Community.Location,
                CommunityName = entity.Community.Name,
                CommunityTraffic = entity.Community.Traffic,
                CreateDateTime = entity.CreateDateTime, //竞然把这个baseDto里面的忘记了
                DecorateStatusId = entity.DecorateStatusId,
                DecorateStatusName = entity.DecorateStatus.Name,
                Direction = entity.Direction,
                Description = entity.Description,
                FloorIndex = entity.FloorIndex,
                //房屋第一张图的缩略图url
                FirstThumbUrl = entity.HousePics.FirstOrDefault() != null ? entity.HousePics.FirstOrDefault().ThumbUrl : null,
                Id = entity.Id,
                LookableDateTime = entity.LookableDateTime,
                MonthRent = entity.MonthRent,
                OwnerName = entity.OwnerName,
                OwnerPhoneNum = entity.OwnerPhoneNum,
                RegionId = entity.Community.RegionId,
                RegionName = entity.Community.Region.Name,
                RoomTypeId = entity.RoomTypeId,
                RoomTypeName = entity.RoomType.Name,
                StatusId = entity.StatusId,
                StatusName = entity.Status.Name,
                TotalFloorCount = entity.TotalFloorCount,
                TypeId = entity.TypeId,
                TypeName = entity.Type.Name
            };
        }

        public HouseDTO GetById(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                var house = cs.GetAll().Include(a => a.Community).Include(a => a.Community.Region)
                    .Include(a => a.Community.Region.City).Include(a => a.Attachments).Include(a => a.HousePics)
                    .Include(a => a.DecorateStatus)
                    .Include(a => a.Status).Include(a => a.RoomType).Include(a => a.Type).AsNoTracking()
                    .SingleOrDefault(a => a.Id == id);
                if (house == null)
                {
                    return null;
                }

                return Entity2DTO(house);
            }
        }

        public long GetTotalCount(long cityId, long typeId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                return cs.GetAll().LongCount(a => a.Community.Region.CityId == cityId && a.TypeId == typeId);
            }
        }

        public HouseDTO[] GetPagedData(long cityId, long typeId, int pageSize, int currentIndex)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                var houses = cs.GetAll().Include(a => a.Community).Include(a => a.Community.Region)
                    .Include(a => a.Community.Region.City).Include(a => a.Attachments).Include(a => a.HousePics)
                    .Include(a => a.DecorateStatus)
                    .Include(a => a.Status).Include(a => a.RoomType).Include(a => a.Type)
                    .Where(a => a.Community.Region.CityId == cityId && a.TypeId == typeId)
                    .OrderBy(a => a.CreateDateTime)
                    .Skip(currentIndex).Take(pageSize);
                return houses.ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public long AddNew(HouseAddNewDTO house)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                HouseEntity houseEntity = new HouseEntity();
                CommonService<AttachmentEntity> attCs = new CommonService<AttachmentEntity>(ctx);
                //拿到传进来的DTO的attachmentIds为主键的房屋配套设施
                var atts = attCs.GetAll().Where(a => house.AttachmentIds.Contains(a.Id));
                foreach (var att in atts)
                {
                    houseEntity.Attachments.Add(att);
                }

                houseEntity.Address = house.Address;
                houseEntity.Area = house.Area;
                houseEntity.CommunityId = house.CommunityId;
                houseEntity.CheckInDateTime = house.CheckInDateTime;
                houseEntity.Description = house.Description;
                houseEntity.DecorateStatusId = house.DecorateStatusId;
                houseEntity.Direction = house.Direction;
                houseEntity.FloorIndex = house.FloorIndex;
                houseEntity.TotalFloorCount = house.TotalFloorCount;
                houseEntity.LookableDateTime = house.LookableDateTime;
                houseEntity.MonthRent = house.MonthRent;
                houseEntity.OwnerName = house.OwnerName;
                houseEntity.OwnerPhoneNum = house.OwnerPhoneNum;
                houseEntity.RoomTypeId = house.RoomTypeId;
                houseEntity.StatusId = house.StatusId;
                houseEntity.TypeId = house.TypeId;
                ctx.Houses.Add(houseEntity);
                ctx.SaveChanges();
                return houseEntity.Id;
            }
        }

        public void Update(HouseDTO house)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                HouseEntity houseEntity = cs.GetById(house.Id);
                houseEntity.Address = house.Address;
                houseEntity.Area = house.Area;
                houseEntity.Attachments.Clear(); //先删掉再添加
                var atts = ctx.Attachments.Where(a => a.IsDeleted == false && house.AttachmentIds.Contains(a.Id));
                foreach (var att in atts)
                {
                    houseEntity.Attachments.Add(att);
                }

                houseEntity.CommunityId = house.CommunityId;
                houseEntity.CheckInDateTime = house.CheckInDateTime;
                houseEntity.Description = house.Description;
                houseEntity.DecorateStatusId = house.DecorateStatusId;   //单元测试不充分呀。。这里写错了，后面才发现
                houseEntity.Direction = house.Direction;
                houseEntity.FloorIndex = house.FloorIndex;
                houseEntity.LookableDateTime = house.LookableDateTime;
                houseEntity.MonthRent = house.MonthRent;
                houseEntity.OwnerName = house.OwnerName;
                houseEntity.OwnerPhoneNum = house.OwnerPhoneNum;
                houseEntity.RoomTypeId = house.RoomTypeId;
                houseEntity.StatusId = house.StatusId;
                houseEntity.TypeId = house.TypeId;
                houseEntity.TotalFloorCount = house.TotalFloorCount;

                ctx.SaveChanges();
            }
        }

        public void MarkDeleted(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                cs.MarkDeleted(id);
            }
        }

        public HousePicDTO[] GetPics(long houseId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                HouseEntity house = cs.GetById(houseId);
                //妈的这里忘了判断pic是否deleted的情况
                return house.HousePics.Where(p => p.IsDeleted == false).Select(p => new HousePicDTO
                {
                    HouseId = p.HouseId,
                    Url = p.Url,
                    ThumbUrl = p.ThumbUrl,
                    Id = p.Id,
                    CreateDateTime = p.CreateDateTime
                }).ToArray();
            }
        }

        public long AddNewHousePic(HousePicDTO housePic)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                HousePicEntity housePicEntity = new HousePicEntity();
                housePicEntity.Url = housePic.Url;
                housePicEntity.ThumbUrl = housePic.ThumbUrl;
                housePicEntity.HouseId = housePic.HouseId;
                ctx.HousePics.Add(housePicEntity);
                ctx.SaveChanges();
                return housePicEntity.Id;
            }
        }

        public void DeleteHousePic(long housePicId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HousePicEntity> cs = new CommonService<HousePicEntity>(ctx);
                cs.MarkDeleted(housePicId);
            }
        }

        public HouseSearchResult Search(HouseSearchOptions options)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                //判断所有的searchoptions
                var items = cs.GetAll().Where(t => t.Community.Region.CityId == options.CityId);
               
                items = items.Where(t => t.TypeId == options.TypeId);
                

                if (options.RegionId != null)
                {
                    items = items.Where(t => t.Community.RegionId == options.RegionId);
                }

                if (options.StartMonthRent != null)
                {
                    items = items.Where(t => t.MonthRent >= options.StartMonthRent);
                }

                if (options.EndMonthRent != null)
                {
                    items = items.Where(t => t.MonthRent <= options.EndMonthRent);
                }

                if (!string.IsNullOrEmpty(options.Keywords))
                {
                    items = items.Where(t => t.Address.Contains(options.Keywords)
                    || t.Description.Contains(options.Keywords)
                    || t.Community.Name.Contains(options.Keywords)
                    || t.Community.Location.Contains(options.Keywords)
                    || t.Community.Traffic.Contains(options.Keywords));
                }
                //使用include连接查询，是立即把外键表都查询出来，正常是用到外键表才去查的，但是这里已知肯定要用到外键表，所以用include，避免延迟加载，不然查询的时候一直去查外键表肯定不好
                items = items.Include(h => h.Attachments).Include(h => h.Community)
                    .Include(h => h.Community.Region).Include(h => h.Community.Region.City).Include(h=>h.Type);
                //搜索结果总条数
                long totalCount = items.LongCount();
                switch (options.OrderByType)
                {
                    case HouseSearchOrderByType.AreaAsc:
                        items = items.OrderBy(t => t.Area);
                        break;
                    case HouseSearchOrderByType.AreaDesc:
                        items = items.OrderByDescending(t => t.Area);
                        break;
                    case HouseSearchOrderByType.MonthRentAsc:
                        items = items.OrderBy(t => t.MonthRent);
                        break;
                    case HouseSearchOrderByType.MonthRentDesc:
                        items = items.OrderByDescending(t => t.MonthRent);
                        break;
                    case HouseSearchOrderByType.CreateDateDesc:
                        items = items.OrderBy(t => t.CreateDateTime);
                        break;
                }
                //一定不要items.Where
                //而要items=items.Where();
                //OrderBy要在Skip和Take之前
                //给用户看的页码从1开始，程序中是从0开始
                items = items.Skip((options.CurrentIndex - 1) * options.PageSize).Take(options.PageSize);
                HouseSearchResult searchResult = new HouseSearchResult();
                searchResult.totalCount = totalCount;
                HouseEntity[] lastItems = items.ToArray();
                List<HouseDTO> houses = new List<HouseDTO>();
                foreach (var houseEntity in lastItems)
                {
                    houses.Add(Entity2DTO(houseEntity)); 
                }

                searchResult.result = houses.ToArray();
                return searchResult;
            }
        }

        public long GetCount(long cityId, DateTime startDateTime, DateTime endDateTime)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                return cs.GetAll().LongCount(a => a.Community.Region.CityId == cityId &&
                    a.CreateDateTime >= startDateTime && a.CreateDateTime <= endDateTime);
                //这里时间居然可以直接用运算符比较。。
            }
        }

        public int GetTodayNewHouseCount(long cityId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseEntity> cs = new CommonService<HouseEntity>(ctx);
                //return cs.GetAll().Count(a =>
                //    a.Community.Region.CityId == cityId && a.CreateDateTime.Date == DateTime.Now.Date);

                //房子创建的时间是在当前时间内的24个小时，就认为是“今天的房源”
                return cs.GetAll().Count(a =>
                    a.Community.Region.CityId == cityId && SqlFunctions.DateDiff("hh", a.CreateDateTime, DateTime.Now) <= 24);
            }
        }
    }
}