using RentHouse.DTO;

namespace RentHouse.IService
{
    public interface IUserService:IServiceMark
    {
        long AddNew(string phoneNum, string password);
        UserDTO GetById(long id);
        UserDTO GetbyPhoneNum(string phoneNum);
        //检查用户名密码是否正确（充分体现出分层的思想）
        bool CheckLogin(string phoneNum, string password);
        void UpdatePwd(long userId, string newPassword);
        //设置用户userId的城市Id
        void SetUserCityId(long userId, long cityId);
        //记录一次登录失败  Increace 增加
        void IncrLoginError(long id);
        //重置登录失败次数
        void ResetLoginError(long id);
        //判断用户是否已被锁定
        bool IsLocked(long id);
    }
}