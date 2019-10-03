using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentHouse.DTO;
using RentHouse.Services;

namespace RentHouse.Tests
{

    [TestClass]
    public class UnitTestHouseApp
    {
        HouseAppointmentService HouseAppSvc = new HouseAppointmentService();
        HouseService HouseSvc = new HouseService();
        [TestMethod]
        public void HouseTest()
        {
            HouseAddNewDTO newDto = new HouseAddNewDTO();
            newDto.Address = "八号楼";
            newDto.Area = 80;  //房屋面积
            newDto.AttachmentIds = new long[]{1,2};
            newDto.CheckInDateTime = DateTime.Now;
            newDto.CommunityId = 2;
            newDto.DecorateStatusId = 8;
            newDto.Description = "房东好人";
            newDto.Direction = "朝南";
            newDto.FloorIndex = 9;
            newDto.LookableDateTime = DateTime.Now;
            newDto.MonthRent = 6000;
            newDto.OwnerName = "何老师";
            newDto.RoomTypeId = 11;
            newDto.OwnerPhoneNum = "18580922452";
            newDto.StatusId = 14;
            newDto.TypeId = 17;
            newDto.TotalFloorCount = 32;
            long houseId = HouseSvc.AddNew(newDto);

            var house = HouseSvc.GetById(houseId);
            Assert.AreEqual(house.Address,newDto.Address);
            CollectionAssert.AreEqual(house.AttachmentIds,newDto.AttachmentIds);
            Assert.AreEqual(house.CityName,"北京");
            Assert.AreEqual(house.DecorateStatusName,"精装修");

            long pic1 = HouseSvc.AddNewHousePic(new HousePicDTO() {HouseId = houseId, ThumbUrl = "suoUrl1.jpg", Url = "Url1.jpg"});
            long pic2 = HouseSvc.AddNewHousePic(new HousePicDTO() { HouseId = houseId, ThumbUrl = "suoUrl2.jpg", Url = "Url2.jpg" });

            CollectionAssert.AreEqual(HouseSvc.GetPics(houseId).Select(p=>p.Id).ToArray(),new long[] {pic1,pic2});
        }

        [TestMethod]
        public void HouseAppTest()
        {
            long houseAppId = HouseAppSvc.AddNew(null, "何小杰", "18580922452", 2, DateTime.Now);
            HouseAppSvc.Follow(4, houseAppId);
            var houseApp = HouseAppSvc.GetById(houseAppId);
            Assert.AreEqual(houseApp.FollowAdminUserName, "jiegege");  
            Assert.AreEqual(houseApp.CommunityName, "清华园");
            Assert.AreEqual(HouseAppSvc.GetTotalCount(1, "未处理"),4);
            Assert.AreEqual(HouseAppSvc.GetPagedData(1, "未处理", 2, 1)[0].FollowAdminUserId, 4);
        }
    }
}
