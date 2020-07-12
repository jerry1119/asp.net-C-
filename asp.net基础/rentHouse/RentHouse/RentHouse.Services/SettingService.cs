using System;
using System.Linq;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class SettingService : ISettingService
    {
        public SettingDTO[] GetAll()
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<SettingEntity> cs = new CommonService<SettingEntity>(ctx);
                return cs.GetAll().ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public SettingDTO Entity2DTO(SettingEntity a)
        {
            return new SettingDTO()
            {
                CreateDateTime = a.CreateDateTime,
                Id = a.Id,
                Name = a.Name,
                Value = a.Value
            };
        }

        public bool? GetBoolValue(string name)
        {
            using (RhDbContext ctx =new RhDbContext())
            {
                var value = GetValue(name);
                if (value==null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToBoolean(value);
                }
            }
        }

        public int? GetIntValue(string name)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                var value = GetValue(name);
                if (value == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(value);
                }
            }
        }

        public string GetValue(string name)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<SettingEntity> cs = new CommonService<SettingEntity>(ctx);
                var valueEntity = cs.GetAll().SingleOrDefault(a => a.Name == name);
                if (valueEntity == null)
                {
                    return null;
                }
                else
                {
                    return valueEntity.Value;
                }
            }
        }

        public void SetBoolValue(string name, bool value)
        {
            SetValue(name,value.ToString());
        }

        public void SetIntValue(string name, int value)
        {
            SetValue(name, value.ToString());
        }
        //新增或更改配置信息
        public void SetValue(string name, string value)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<SettingEntity> cs= new CommonService<SettingEntity>(ctx);
                var settingEntity = cs.GetAll().SingleOrDefault(a => a.Name == name);
                if (settingEntity==null) //没有则新增
                {
                    ctx.Settings.Add(new SettingEntity()
                    {
                        Name = name,
                        Value = value
                    });
                }
                else
                {
                    settingEntity.Value = value;
                }
                ctx.SaveChanges();
            }
        }
    }
}