using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentHouse.Services;

namespace RentHouse.Tests
{
    [TestClass]
    public class UnitTestAdmniUser
    {
        private AdminUserService adminUserService = new AdminUserService();
        [TestMethod]
        public void TestAddAdminUser()
        {
            
            string phoneNum =  Guid.NewGuid().ToString().Substring(0,11);
            long uId = adminUserService.AddAdminUser("张三", phoneNum, "123456", "123@qq.com",null);
            var user = adminUserService.GetById(uId);
            Assert.AreEqual(user.Name, "张三");
            Assert.AreEqual(user.PhoneNum, phoneNum);
            Assert.AreEqual(user.Email, "123@qq.com");
            Assert.IsNull(user.CityId);
            Assert.IsTrue(adminUserService.CheckLogin(phoneNum,"123456"));
            Assert.IsFalse(adminUserService.CheckLogin(phoneNum, "123"));
            adminUserService.GetAll();
            Assert.IsNotNull(adminUserService.GetByPhoneNum(phoneNum));
            adminUserService.MarkDeleted(uId);
        }
        [TestMethod]
        public void HasPermission()
        {
            PermissionService permissionService = new PermissionService();
            //权限项1
            string permName1 = Guid.NewGuid().ToString();
            long permId1 = permissionService.AddPermission(permName1, permName1);
            //权限项2
            string permName2 = Guid.NewGuid().ToString();
            long permId2 = permissionService.AddPermission(permName2, permName2);
            //用户
            string phoneNum = Guid.NewGuid().ToString().Substring(0, 11);
            long adminUserId = adminUserService.AddAdminUser("李四", phoneNum, "123", "234@qq.com", null);
            //角色1,2
            RoleService roleService = new RoleService();
            string roleName1 = Guid.NewGuid().ToString();
            string roleName2 = Guid.NewGuid().ToString();
            long roleId1 = roleService.AddNew(roleName1);
            long roleId2 = roleService.AddNew(roleName2);
            //给角色1添加权限项1
            permissionService.AddPermIds(roleId1, new long[] { permId1 });
            //给用户adminuser添加角色1
            roleService.AddRoleIds(adminUserId, new long[] { roleId1 });

            Assert.IsTrue(adminUserService.HasPermission(adminUserId, permName1));
            Assert.IsFalse(adminUserService.HasPermission(adminUserId, permName2));

        }
    }
}
