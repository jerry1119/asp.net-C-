using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentHouse.Services;

namespace RentHouse.Tests
{
    [TestClass]
    public class UnitTestSetting
    {
        [TestMethod]
        public void TestMethod1()
        {
            SettingService settingService = new SettingService();
            string name = Guid.NewGuid().ToString();
            string value = Guid.NewGuid().ToString();
            Assert.IsNull(settingService.GetValue(name));
            settingService.SetValue(name,value);
            Assert.AreEqual(settingService.GetValue(name),value);
            settingService.SetIntValue(name,3);
            Assert.AreEqual(settingService.GetIntValue(name),3);
        }
    }
}
