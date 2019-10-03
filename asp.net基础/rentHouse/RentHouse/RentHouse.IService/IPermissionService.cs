using RentHouse.DTO;

namespace RentHouse.IService
{
    //权限控制
    public interface IPermissionService:IServiceMark
    {
        long AddPermission(string permName, string description);

        void UpdatePermission(long id, string permName, string description);

        void MarkDeleted(long id);

        PermissionDTO GetById(long id);

        PermissionDTO[] GetAll();

        PermissionDTO GetByName(string name);

        //获取角色的权限
        PermissionDTO[] GetByRoleId(long roleId);

        //给角色roleId添加权限项 roleId permIds
        void AddPermIds(long roleId, long[] permIds);

        //更新roleId权限项，先删除再添加
        void UpdatePermIds(long roleId, long[] permIds);
    }
}