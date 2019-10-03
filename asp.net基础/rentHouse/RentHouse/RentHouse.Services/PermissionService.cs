using System;
using System.Linq;
using System.Security;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class PermissionService : IPermissionService
    {
        public void AddPermIds(long roleId, long[] permIds)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RoleEntity> roleCs = new CommonService<RoleEntity>(ctx);
                RoleEntity role = roleCs.GetById(roleId);
                if (role == null)
                {
                    throw new ArgumentException("roleId不存在 "+roleId);
                }
                CommonService<PermissionEntity> permCs = new CommonService<PermissionEntity>(ctx);
                var perms = permCs.GetAll().Where(a=>permIds.Contains(a.Id)).ToArray();
                foreach (var perm in perms)
                {
                    role.Permissions.Add(perm);
                }

                ctx.SaveChanges();
            }
        }

        public long AddPermission(string permName, string description)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(ctx);
                var exists = cs.GetAll().Any(a => a.Name == permName);
                if (exists)
                {
                    throw new ArgumentException("此权限项已存在");
                }
                PermissionEntity permissionEntity = new PermissionEntity()
                {
                    Name = permName,
                    Description = description
                };
                ctx.Permissions.Add(permissionEntity);
                ctx.SaveChanges();
                return permissionEntity.Id;
            }
        }

        public PermissionDTO[] GetAll()
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(ctx);
                return cs.GetAll().ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public PermissionDTO Entity2DTO(PermissionEntity a)
        {
            return new PermissionDTO()
            {
                CreateDateTime = a.CreateDateTime,
                Description = a.Description,
                Id = a.Id,
                Name = a.Name
            };
        }

        public PermissionDTO GetById(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(ctx);
                //return Entity2DTO(cs.GetById(id));
                var perm = cs.GetById(id);
                return perm == null ? null : Entity2DTO(perm);
            }
        }

        public PermissionDTO GetByName(string name)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(ctx);
                var perm = cs.GetAll().SingleOrDefault(a => a.Name == name);
                return perm == null ? null : Entity2DTO(perm);
            }
        }

        public PermissionDTO[] GetByRoleId(long roleId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RoleEntity> roleCs = new CommonService<RoleEntity>(ctx);
                var role = roleCs.GetById(roleId);
                if (role==null)
                {
                    throw new ArgumentException("该角色不存在");
                }

                return role.Permissions.ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public void MarkDeleted(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(ctx);
                cs.MarkDeleted(id);
            }
        }

        public void UpdatePermIds(long roleId, long[] permIds)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<RoleEntity> roleCs = new CommonService<RoleEntity>(ctx);
                var role =  roleCs.GetById(roleId);
                if (role==null)
                {
                    throw new ArgumentException("该角色不存在");
                }
                CommonService<PermissionEntity> permCs = new CommonService<PermissionEntity>(ctx);
                role.Permissions.Clear();
                if (permIds!=null)
                {
                    var perms = permCs.GetAll().ToList().Where(a => permIds.Contains(a.Id));
                    foreach (var perm in perms)
                    {
                        role.Permissions.Add(perm);
                    }
                }
                ctx.SaveChanges();
            }
        }

        public void UpdatePermission(long id, string permName, string description)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<PermissionEntity> cs = new CommonService<PermissionEntity>(ctx);
                var permEntity = cs.GetById(id);
                if (permEntity==null)
                {
                    throw new ArgumentException("id不存在  "+id);
                }

                permEntity.Name = permName;
                permEntity.Description = description;
                ctx.SaveChanges();
            }
        }
    }
}