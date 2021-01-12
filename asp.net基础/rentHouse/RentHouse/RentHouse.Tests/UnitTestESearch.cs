using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentHouse.DTO;
using RentHouse.Services;
using RentHouse.Web.Common;

namespace RentHouse.Tests
{
    [TestClass]
    public class UnitTestESearch
    {
        HouseService HouseSvc = new HouseService();
        [TestMethod]
        public async Task TestIndex()
        {
            HouseAddNewDTO newDto = new HouseAddNewDTO();
            newDto.Address = "八号楼";
            newDto.Area = 80;  //房屋面积
            newDto.AttachmentIds = new long[] { 1, 2 };
            newDto.CheckInDateTime = DateTime.Now;
            newDto.CommunityId = 2;
            newDto.DecorateStatusId = 8;
            newDto.Description = "房东好人";
            newDto.Direction = "朝南";
            newDto.FloorIndex = 9;
            newDto.LookableDateTime = DateTime.Now;
            newDto.MonthRent = 4000;
            newDto.OwnerName = "何老师";
            newDto.RoomTypeId = 11;
            newDto.OwnerPhoneNum = "18580922452";
            newDto.StatusId = 14;
            newDto.TypeId = 17;
            newDto.TotalFloorCount = 32;
            long houseId = HouseSvc.AddNew(newDto);

            var house = HouseSvc.GetById(houseId);
            bool result =  await ESearchHelper.IndexAsync("house", houseId.ToString(), house);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestSearch()
        {
            string responseBody = ESearchHelper.Search("house", new
            {
                from = 0,
                size = 10,
                query = new
                {
                    OwnerName = "何老师"
                }
            });
            Console.WriteLine(responseBody);
            Console.ReadKey();
        }
    }
}