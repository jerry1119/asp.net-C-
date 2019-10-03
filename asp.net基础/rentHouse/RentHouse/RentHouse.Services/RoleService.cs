
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class RoleService : IRoleService
    {
        public long AddNew(string roleName)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                RoleEntity role = new RoleEntity();
                role.Name = roleName;
                ctx.Roles.Add(role);
                ctx.SaveChanges();
                return role.Id;
            }
        }

        public void AddRoleIds(long adminUserId, long[] roleIds)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> adminUserCs = new CommonService<AdminUserEntity>(ctx);
                var adminUser = adminUserCs.GetById(adminUserId);
                if (adminUser==null)
                {
                    throw new ArgumentException("管理员用户Id不存在 "+adminUserId);
                }
                CommonService<RoleEntity> roleCs = new CommonService<RoleEntity>(ctx);
                var roles = roleCs.GetAll().Where(a => roleIds.Contains(a.Id)).ToList().ToArray();
                foreach (var role in roles)
                {
                    adminUser.Roles.Add(role);
                }

                ctx.SaveChanges();
            }
        }

        public RoleDTO[] GetAll()
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(ctx);
                return cs.GetAll().ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public RoleDTO Entity2DTO(RoleEntity a)
        {
            return new RoleDTO()
            {
                Id = a.Id,
                CreateDateTime = a.CreateDateTime,
                Name = a.Name
            };
        }

        public RoleDTO[] GetByAdminUserId(long adminUserId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> cs = new CommonService<AdminUserEntity>(ctx);
                var adminUser = cs.GetById(adminUserId);
                if (adminUser==null)
                {
                    throw new ArgumentException("此用户不存在");
                }

                return adminUser.Roles.ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public RoleDTO GetById(long roleId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(ctx);
                var role = cs.GetById(roleId);
                return role == null ? null : Entity2DTO(role);
            }
        }

        public RoleDTO GetByName(string roleName)
        {
            using (RhDbContext ctx =new RhDbContext())
            {
                CommonService<RoleEntity> cs= new CommonService<RoleEntity>(ctx);
                var role = cs.GetAll().SingleOrDefault(a => a.Name == roleName);
                return role == null ? null : Entity2DTO(role);
            }
        }

        public void MarkDelete(long roleId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(ctx);
                cs.MarkDeleted(roleId);
            }
        }

        public void Update(long roleId, string roleName)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RoleEntity> cs = new CommonService<RoleEntity>(ctx);
                var role = cs.GetById(roleId);
                if (role == null)
                {
                    throw new ArgumentException("此角色不存在");
                }

                role.Name = roleName;
                ctx.SaveChanges();
            }
        }

        public void UpdateRoleIds(long adminUserId, long[] roleIds)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> adminUserCs = new CommonService<AdminUserEntity>(ctx);
                var adminUser = adminUserCs.GetById(adminUserId);
                if (adminUser == null)
                {
                    throw new ArgumentException("管理员用户Id不存在 " + adminUserId);
                }
                CommonService<RoleEntity> roleCs = new CommonService<RoleEntity>(ctx);
                var roles = roleCs.GetAll().Where(a => roleIds.Contains(a.Id)).ToList().ToArray();
                adminUser.Roles.Clear();
                foreach (var role in roles)
                {
                    adminUser.Roles.Add(role);
                }

                ctx.SaveChanges();
            }
        }
    }
}
