using RentHouse.DTO;

namespace RentHouse.IService
{
    public interface IAttachmentService:IServiceMark
    {
        //获取所有的设施
        AttachmentDTO[] GetAll();
        //获取houseID拥有的设施
        AttachmentDTO[] GetById(long houseId);
    }
}