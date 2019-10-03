using System;
using System.Data.Entity;
using System.Linq;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class AttachmentService:IAttachmentService
    {
        public AttachmentDTO[] GetAll()
        {
            using (RhDbContext ctx = new RhDbContext())
            {
               return ctx.Attachments.Where(a=>a.IsDeleted==false).AsNoTracking().ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        private AttachmentDTO Entity2DTO(AttachmentEntity attachmentEntity)
        {
            return new AttachmentDTO()
            {
                CreateDateTime = attachmentEntity.CreateDateTime,
                IconName = attachmentEntity.IconName,
                Id = attachmentEntity.Id,
                Name = attachmentEntity.Name
            };
        }

        public AttachmentDTO[] GetById(long houseId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                var house = ctx.Houses.Where(h => h.IsDeleted == false).Include(h => h.Attachments).AsNoTracking()
                    .SingleOrDefault(h => h.Id == houseId);
                if (house==null)
                {
                    throw new ArgumentException("houseId" + houseId + "不存在");
                }
                //直接ToList都拿到内存中，免得频繁查数据库
                return house.Attachments.ToList().Select(Entity2DTO).ToArray();
            }
        }
    }
}