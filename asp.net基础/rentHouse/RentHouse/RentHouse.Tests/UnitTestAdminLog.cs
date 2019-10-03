using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentHouse.Services;

namespace RentHouse.Tests
{
    [TestClass]
    public class UnitTestAdminLog
    {
        [TestMethod]
        public void TestAddNew()
        {
            AdminLogService adminLog = new AdminLogService();
            adminLog.AddNewLog(4,"测试内容");
        }

        
    }
}
