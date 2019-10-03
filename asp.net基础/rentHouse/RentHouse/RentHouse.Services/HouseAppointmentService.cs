using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class HouseAppointmentService:IHouseAppointmentService
    {
        public long AddNew(long? userId, string name, string phoneNum, long houseId, DateTime visitDate)
        {
            HouseAppointmentEntity ha = new HouseAppointmentEntity();
            ha.UserId = userId;
            ha.Name = name;
            ha.PhoneNum = phoneNum;
            ha.Status = "未处理"; //这个忘了
            ha.HouseId = houseId;
            ha.VisitDate = visitDate;
            using (RhDbContext ctx = new RhDbContext())
            {
                ctx.HouseAppointments.Add(ha);
                ctx.SaveChanges();
                return ha.Id;
            }
        }
        /// <summary>
        /// 带看人 抢单
        /// </summary>
        /// <param name="adminUserId">带看人ID</param>
        /// <param name="houseAppointmentId">预约单Id</param>
        /// <returns></returns>
        public bool Follow(long adminUserId, long houseAppointmentId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseAppointmentEntity> cs = new CommonService<HouseAppointmentEntity>(ctx);
                var appointment =  cs.GetById(houseAppointmentId);
                if (appointment == null)
                {
                    throw new ArgumentException("不存在的订单Id");
                }
                //如果已有带看人，判断是否为当前用户
                if (appointment.FollowAdminUserId!=null)
                {
                    return appointment.FollowAdminUserId == adminUserId;
                }
                //如果/FollowAdminUserId为null，说明有抢的机会
                appointment.FollowAdminUserId = adminUserId;
                appointment.FollowDateTime = DateTime.Now;
                try
                {
                    ctx.SaveChanges();
                    return true;
                }//如果抛出DbUpdateConcurrencyException说明抢单失败（乐观锁）
                catch(DbUpdateConcurrencyException)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 多表的联合查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HouseAppointmentDTO GetById(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseAppointmentEntity> cs = new CommonService<HouseAppointmentEntity>(ctx);
                var app =  cs.GetAll().Include(h => h.House).Include("House.Community").Include("House.Community.Region").Include(h=>h.FollowAdminUser).AsNoTracking().SingleOrDefault(h => h.Id == id);
                if (app==null)
                {
                    throw new ArgumentException("不存在的预约号");
                }

                return Entity2DTO(app);
            }
        }

        private HouseAppointmentDTO Entity2DTO(HouseAppointmentEntity entity)
        {
            return new HouseAppointmentDTO()
            {
                CommunityName = entity.House.Community.Name,
                CreateDateTime = entity.CreateDateTime,
                FollowAdminUserId = entity.FollowAdminUserId,
                FollowAdminUserName = entity.FollowAdminUser?.Name,
                FollowDateTime = entity.FollowDateTime,
                HouseId = entity.HouseId,
                Id = entity.Id,
                Name = entity.Name,
                PhoneNum = entity.PhoneNum,
                RegionName = entity.House.Community.Region.Name,
                VisitDate = entity.VisitDate,
                Status = entity.Status,
                HouseAddress = entity.House.Address
            };
        }

        public long GetTotalCount(long cityId, string status)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseAppointmentEntity> cs =new CommonService<HouseAppointmentEntity>(ctx);
                var count = cs.GetAll().AsNoTracking().LongCount(h =>
                    h.Status == status && h.House.Community.Region.CityId == cityId);
                return count;
            }
        }

        public HouseAppointmentDTO[] GetPagedData(long cityId, string status, int pageSize, int currentIndex)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<HouseAppointmentEntity> cs = new CommonService<HouseAppointmentEntity>(ctx);
                var pageData = cs.GetAll()
                    .Include(h=>h.House)
                    .Include(nameof(HouseAppointmentEntity.House)+"."+nameof(HouseEntity.Community))
                    .Include(nameof(HouseAppointmentEntity.House) + "." + nameof(HouseEntity.Community)+"."+nameof(CommunityEntity.Region))
                    .Include(h=>h.FollowAdminUser).AsNoTracking().Where(h =>
                    h.Status == status && h.House.Community.Region.CityId == cityId).OrderByDescending(h=>h.CreateDateTime).Skip(currentIndex).Take(pageSize).ToList().Select(Entity2DTO).ToArray();
                    //这里为啥要先toList 是不是因为这个了就不会延迟加载 跟最后的 toArray没关系好像
                    //新理解：tolist是立即加载，不会延迟加载，而include的作用也是把链接的几张表立即加载，所以这里不用tolist才对，而toarray则是把IQueryble的变为数组，不是一回事了
                    //新理解：tolist的作用是把表先全部读到内存中，后面再做查询
                //skip之前一定要先orderBy
                return pageData;
            }
        }
    }
}