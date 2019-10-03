using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentHouse.Common;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class AdminUserService:IAdminUserService
    {
        public long AddAdminUser(string name, string phoneNum, string password, string email, long? cityId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                //假如手机号已被注册,就返回-1
                if (commonService.GetAll().Any(a=>a.PhoneNum==phoneNum))
                {
                    return -1;
                }
                //密码盐 可以用生成验证码的那个随机算一个出来
                string pwdSalt =  CommonHelper.GenerateCaptchaCode(5);
                AdminUserEntity newAdminUser = new AdminUserEntity()
                {
                    Name = name,
                    PhoneNum = phoneNum,
                    CityId = cityId,
                    PasswordSalt = pwdSalt,
                    PasswordHash = CommonHelper.CalcMd5(password+pwdSalt),
                    Email = email,
                };
                ctx.AdminUsers.Add(newAdminUser);
                ctx.SaveChanges();
                return newAdminUser.Id;
            }
        }

        public void UpdateAdminUser(long id, string name, string phoneNum, string password, string email, long? cityId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                var adminUser = commonService.GetById(id);
                if (adminUser == null)
                {
                    throw new ArgumentException("找不到id为"+id+"的管理员");
                }
                adminUser.Name = name;
                adminUser.PhoneNum = phoneNum;
                if (!string.IsNullOrEmpty(password))
                {
                    adminUser.PasswordHash = CommonHelper.CalcMd5(password+adminUser.PasswordSalt);
                }
                adminUser.Email = email;
                adminUser.CityId = cityId;
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId">如果cityId为null则查出总部的员工</param>
        /// <returns></returns>
        public AdminUserDTO[] GetAll(long? cityId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                //不用判断cityId是否为null，为null他就查出总部的,如果cityId不为null但是不存在就应该抛出异常，找到问题
                //TODO 自己单元测试下CityId不存在的情况
                return commonService.GetAll().Include(a=>a.City).AsNoTracking().Where(a => a.CityId == cityId).ToList().Select(a => Entity2DTO(a)).ToArray();
            }
        }

        public AdminUserDTO[] GetAll()
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                //因为转换成DTO一定会用到city导航属性，为了防止延迟加载就直接用include
                return commonService.GetAll().Include(a=>a.City).AsNoTracking().ToList().Select(a => Entity2DTO(a)).ToArray();
                //linq语句翻译成表达式树翻译成sql语句，entity2DTO这种写法不被ef支持，所以先ToList通过ef查到内存中在执行后面的不被支持的写法
            }
        }

        public AdminUserDTO GetById(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                // var adminUser = commonService.GetById(id);直接用写好的这个就没法用include了
                var adminUser = commonService.GetAll().Include(a => a.City).AsNoTracking()
                    .SingleOrDefault(a => a.Id == id);
                if (adminUser==null)
                {
                    return null;
                }
                return Entity2DTO(adminUser);
            }
        }

        private AdminUserDTO Entity2DTO(AdminUserEntity adminUser)
        {
            AdminUserDTO dto = new AdminUserDTO();
            dto.CityId = adminUser.CityId;
            //这是我没想到的，。
            dto.CityName = adminUser.City != null ? adminUser.City.Name : "总部";
            dto.CreateDateTime = adminUser.CreateDateTime;
            dto.Email = adminUser.Email;
            dto.Id = adminUser.Id;
            dto.LastLoginErrorDateTime = adminUser.LastLoginErrorDateTime;
            dto.LoginErrorTimes = adminUser.LoginErrorTimes;
            dto.Name = adminUser.Name;
            dto.PhoneNum = adminUser.PhoneNum;
            return dto;
        }

        public AdminUserDTO GetByPhoneNum(string phoneNum)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                AdminUserEntity adminUser = commonService.GetAll().SingleOrDefault(a => a.PhoneNum == phoneNum);
                //如果手机号不存在就返回null，如果有不止一个号码就抛出异常
                if (adminUser == null)
                {
                    return null;
                }
                return Entity2DTO(adminUser);
            }
        }
        //检查用户名密码是否正确
        public bool CheckLogin(string phoneNum, string password)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                AdminUserEntity adminUser = commonService.GetAll().SingleOrDefault(a => a.PhoneNum == phoneNum);
                //手机号不存在
                if (adminUser==null)
                {
                    return false;
                }
                //密码盐来转换密码
                if (adminUser.PasswordHash==CommonHelper.CalcMd5(password+adminUser.PasswordSalt))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }
        //软删除。TODO 这里是不是应该返回是否删除成功呢？
        public void MarkDeleted(long adminUserId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                commonService.MarkDeleted(adminUserId);
            }
        }

        public bool HasPermission(long adminUserId, string permissionName)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                var adminUser = commonService.GetAll().Include(a=>a.Roles).AsNoTracking().SingleOrDefault(a=>a.Id==adminUserId);
                if (adminUser==null)
                {
                    throw new Exception("找不到id为"+adminUserId+"的用户");
                }
                //每个Role都有一个Permissions属性
                //Roles.SelectMany(r => r.Permissions)就是遍历Roles的每一个Role
                //然后把每个Role的Permissions放到一个集合中
                //IEnumerable<PermissionEntity>
                return adminUser.Roles.SelectMany(r => r.Permissions).Any(a => a.Name == permissionName);
            }
        }

        public void RecordLoginError(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                var adminUser =  commonService.GetById(id);
                adminUser.LoginErrorTimes = adminUser.LoginErrorTimes++;
                adminUser.LastLoginErrorDateTime = DateTime.Now;
                ctx.SaveChanges();
            }
        }

        public void ResetLoginError(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<AdminUserEntity> commonService = new CommonService<AdminUserEntity>(ctx);
                var adminUser = commonService.GetById(id);
                adminUser.LoginErrorTimes = 0;
                ctx.SaveChanges();
            }
        }
    }
}
