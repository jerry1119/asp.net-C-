using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentHouse.Services;

namespace RentHouse.Tests
{
    [TestClass]
    public class UnitTestIdName
    {
        private static IdNameService idNameService = new IdNameService();
        private static long id1;
        private static long id2;
        [TestMethod]
        public void TestMethod1()
        {
            string typeName = Guid.NewGuid().ToString();
            string name1 = Guid.NewGuid().ToString();
            string name2 = Guid.NewGuid().ToString();
            id1 = idNameService.AddNew(typeName, name1);
            id2 = idNameService.AddNew(typeName, name2);
            Assert.AreEqual(idNameService.GetById(id1).Name,name1);
            Assert.AreEqual(idNameService.GetAll(typeName).Length,2);
            Assert.AreEqual(idNameService.GetAll(typeName)[1].Name, name2);
        }
        [ClassCleanup]
        public static void CleanUp()
        {
            if (id1!=0)
            {
                idNameService.MarkDelete(id1);
            }

            if (id2!=0)
            {
                idNameService.MarkDelete(id2);
            }
        }
    }
}
