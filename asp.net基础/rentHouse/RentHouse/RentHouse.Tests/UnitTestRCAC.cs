using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentHouse.Services;

namespace RentHouse.Tests
{
    /// <summary>
    /// 用户 角色 权限测试
    /// </summary>
    [TestClass]
    public class UnitTestRCAC
    {
        private static AdminUserService adminUserService = new AdminUserService();
        private static PermissionService permissionService = new PermissionService();
        private static RoleService roleService = new RoleService();
        private static long adminUserId;
        [TestMethod]
        public void TestUserRole()
        {
            //权限项1
            string permName1 = Guid.NewGuid().ToString();
            long permId1 = permissionService.AddPermission(permName1, permName1);
            //权限项2
            string permName2 = Guid.NewGuid().ToString();
            long permId2 = permissionService.AddPermission(permName2, permName2);
            //用户
            string phoneNum = Guid.NewGuid().ToString().Substring(0, 11);
            adminUserId = adminUserService.AddAdminUser("wangwu", phoneNum, "123", "234@qq.com", null);
            //角色1,2
            string roleName1 = Guid.NewGuid().ToString();
            string roleName2 = Guid.NewGuid().ToString();
            long roleId1 = roleService.AddNew(roleName1);
            long roleId2 = roleService.AddNew(roleName2);
            //给角色1添加权限项1
            permissionService.AddPermIds(roleId1, new long[] { permId1 });
            //给角色2添加权限项2
            permissionService.AddPermIds(roleId2, new long[] { permId2 });
            //给用户adminuser添加角色1
            roleService.AddRoleIds(adminUserId, new long[] { roleId1 });

            Assert.IsTrue(adminUserService.HasPermission(adminUserId, permName1));
            Assert.IsFalse(adminUserService.HasPermission(adminUserId, permName2));

            roleService.UpdateRoleIds(adminUserId,new long[]{roleId2});

            Assert.IsFalse(adminUserService.HasPermission(adminUserId,permName1));
            Assert.IsTrue(adminUserService.HasPermission(adminUserId, permName2));
            CollectionAssert.AreEqual(roleService.GetByAdminUserId(adminUserId).Select(a=>a.Id).ToArray(),new long[]{roleId2});
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            if (adminUserId!=0)
            {
                adminUserService.MarkDeleted(adminUserId);
            }
        }
    }
}
