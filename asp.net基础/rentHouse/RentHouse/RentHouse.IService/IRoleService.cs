using RentHouse.DTO;

namespace RentHouse.IService
{
    public interface IRoleService:IServiceMark
    {
        //新增角色
        long AddNew(string roleName);
        void Update(long roleId, string roleName);
        void MarkDelete(long roleId);
        RoleDTO GetById(long roleId);
        RoleDTO GetByName(string roleName);
        RoleDTO[] GetAll();
        //给用户(adminUser)添加角色，也就是添加权限
        void AddRoleIds(long adminUserId, long[] roleIds);
        //更新权限，先删除再添加
        void UpdateRoleIds(long adminUserId, long[] roleIds);
        //获取用户的角色，间接知道用户有哪些权限
        RoleDTO[] GetByAdminUserId(long adminUserId);
    }
}