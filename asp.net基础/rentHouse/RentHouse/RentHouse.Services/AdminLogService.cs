using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class AdminLogService:IAdminLogService
    {
        public void AddNewLog(long adminUserId, string message)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                ctx.AdminUserLogs.Add(new AdminLogEntity()
                {
                    AdminUserId = adminUserId,
                    Message = message
                });
                ctx.SaveChanges();
            }
        }

        public AdminLogDTO GetById(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminLogEntity> commonService = new CommonService<AdminLogEntity>(ctx);
                var adminLogEntity = commonService.GetAll().Include(a=>a.AdminUser).AsNoTracking().SingleOrDefault(a=>a.Id==id);
                if (adminLogEntity==null)
                {
                    return null;
                }
                return Entity2DTO(adminLogEntity);
            }
        }

        private AdminLogDTO Entity2DTO(AdminLogEntity adminLogEntity)
        {
            return new AdminLogDTO()
            {
                AdminUserId = adminLogEntity.AdminUserId,
                AdminUserName = adminLogEntity.AdminUser.Name,
                AdminUserPhoneNum = adminLogEntity.AdminUser.PhoneNum,
                CreateDateTime = adminLogEntity.CreateDateTime,
                Id = adminLogEntity.Id,
                Message = adminLogEntity.Message
            };
        }
    }
}
