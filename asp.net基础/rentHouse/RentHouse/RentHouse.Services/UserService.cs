using System;
using System.Linq;
using RentHouse.Common;
using RentHouse.DTO;
using RentHouse.IService;
using ZSZ.Service.Entities;

namespace RentHouse.Services
{
    public class UserService : IUserService
    {
        public long AddNew(string phoneNum, string password)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                //检查手机号不能重复
                CommonService<UserEntity> cs = new CommonService<UserEntity>(ctx);
                bool exists = cs.GetAll().Any(a => a.PhoneNum == phoneNum);
                if (exists)
                {
                    throw new ArgumentException("手机号已存在");
                }
                string salt = CommonHelper.GenerateCaptchaCode(5);
                string pwdHash = CommonHelper.CalcMd5(salt + password);
                UserEntity user = new UserEntity();
                user.PhoneNum = phoneNum;
                user.PasswordSalt = salt;
                user.PasswordHash = pwdHash;
                ctx.Users.Add(user);
                ctx.SaveChanges();
                return user.Id;
            }
        }

        public bool CheckLogin(string phoneNum, string password)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                //检查手机号是否注册
                CommonService<UserEntity> cs = new CommonService<UserEntity>(ctx);
                UserEntity user = cs.GetAll().SingleOrDefault(a => a.PhoneNum == phoneNum);
                if (user==null)
                {
                    return false;
                }
                string passwordHash = CommonHelper.CalcMd5(user.PasswordSalt + password);
                return user.PasswordHash == passwordHash;
            }
        }

        public UserDTO GetById(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                
                CommonService<UserEntity> cs = new CommonService<UserEntity>(ctx);
                UserEntity user = cs.GetById(id);
                return user == null ? null : Entity2DTO(user);
            }
        }

        private UserDTO Entity2DTO(UserEntity user)
        {
            UserDTO userDto = new UserDTO();
            userDto.CityId = user.CityId;
            userDto.LastLoginErrorDateTime = user.LastLoginErrorDateTime;
            userDto.LoginErrorTimes = user.LoginErrorTimes;
            userDto.PhoneNum = user.PhoneNum;
            userDto.Id = user.Id;
            userDto.CreateDateTime = user.CreateDateTime;
            return userDto;
        }

        public UserDTO GetbyPhoneNum(string phoneNum)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(ctx);
                UserEntity user = cs.GetAll().SingleOrDefault(a => a.PhoneNum == phoneNum);
                return user == null ? null : Entity2DTO(user);
            }
        }

        public void IncrLoginError(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(ctx);
                UserEntity user = cs.GetById(id);
                if (user==null)
                {
                    throw new ArgumentException("用户不存在 "+id);
                }
                user.LastLoginErrorDateTime = DateTime.Now;
                user.LoginErrorTimes++;
                ctx.SaveChanges();
            }
        }

        public bool IsLocked(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                var user = GetById(id);
                if (user == null)
                {
                    throw new ArgumentException("用户不存在 " + id);
                }
                //错误登录次数>=5，最后一次登录错误时间在30分钟之内
                return user.LoginErrorTimes > 4&&user.LastLoginErrorDateTime>DateTime.Now.AddMinutes(-30);
            }
        }

        public void ResetLoginError(long id)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(ctx);
                UserEntity user = cs.GetById(id);
                if (user == null)
                {
                    throw new ArgumentException("用户不存在 " + id);
                }
                user.LoginErrorTimes=0;
                user.LastLoginErrorDateTime = null;
                ctx.SaveChanges();
            }
        }

        public void SetUserCityId(long userId, long cityId)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(ctx);
                UserEntity user = cs.GetById(userId);
                if (user == null)
                {
                    throw new ArgumentException("用户不存在 " + userId);
                }
                user.CityId = cityId;
                ctx.SaveChanges();
            }
        }

        public void UpdatePwd(long userId, string newPassword)
        {
            using (RhDbContext ctx = new RhDbContext())
            {
                CommonService<UserEntity> cs = new CommonService<UserEntity>(ctx);
                UserEntity user = cs.GetById(userId);
                if (user == null)
                {
                    throw new ArgumentException("用户不存在 " + userId);
                }

                string salt = CommonHelper.GenerateCaptchaCode(5);
                user.PasswordSalt = salt;
                user.PasswordHash = CommonHelper.CalcMd5(salt+newPassword);
                ctx.SaveChanges();
            }
        }
    }
}