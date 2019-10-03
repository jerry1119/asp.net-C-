using System;
using System.Linq;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class IdNameService : IIdNameService
    {
        public long AddNew(string typeName, string name)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                IdNameEntity idName = new IdNameEntity()
                {
                    Name = name,
                    TypeName = typeName
                };
                //TODO:检查重复的情况
                ctx.IdNames.Add(idName);
                ctx.SaveChanges();
                return idName.Id;
            }
        }

        public IdNameDTO[] GetAll(string typeName)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<IdNameEntity> cs = new CommonService<IdNameEntity>(ctx);
                //直接ToList都拿到内存中，免得频繁查数据库
                return cs.GetAll().Where(a => a.TypeName == typeName).ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public IdNameDTO GetById(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<IdNameEntity> cs = new CommonService<IdNameEntity>(ctx);
                return Entity2DTO( cs.GetById(id));
            }
        }

        public IdNameDTO Entity2DTO(IdNameEntity a)
        {
            return new IdNameDTO()
            {
                Id = a.Id,
                CreateDateTime = a.CreateDateTime,
                Name = a.Name,
                TypeName = a.TypeName
            };
        }

        public void MarkDelete(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<IdNameEntity> cs = new CommonService<IdNameEntity>(ctx);
                cs.MarkDeleted(id);
            }
        }
    }
}