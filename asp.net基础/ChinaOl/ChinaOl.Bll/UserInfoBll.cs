using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaOl.Bll
{
    public class UserInfoBll
    {
        Dal.UserInfoDal UserInfoDal = new Dal.UserInfoDal();
        //获取用户列表
        public List<UserInfo> GetList()
        {
            return UserInfoDal.GetList();
        }
        //添加数据
        public bool AddUserInfo(UserInfo userInfo)
        {
            return UserInfoDal.AddUserInfo(userInfo) > 0;
        }
        //根据id获取用户的信息
        public UserInfo GetUserInfo(int id)
        {
            return UserInfoDal.GetUserInfo(id);

        }
        //根据UserName获取用户的信息
        public UserInfo GetUserInfo(string userName)
        {
            return UserInfoDal.GetUserInfo(userName);

        }
        /// <summary>
        ///用户登录信息校验
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="msg">登录信息</param>
        /// <param name="userinfo">登录用户信息</param>
        /// <returns></returns>
        public bool validateUserInfo(string userName, string userPwd, out string msg, out UserInfo userInfo)
        {
            userInfo = UserInfoDal.GetUserInfo(userName);
            if (userInfo != null)
            {
                if (userInfo.UserPwd == userPwd)
                {
                    msg = "登录成功";
                    return true;
                }
                else
                {
                    msg = "用户名或密码错误";
                    return false;
                }
            }
            else
            {
                msg = "不存在此用户";
                return false;
            }
         
        }
        //根据id删除用户的信息
        public int DeleteUserInfo(int id)
        {
            return UserInfoDal.DeleteUserInfo(id);
        }
        //修改用户信息
        public bool EditUserInfo(UserInfo userInfo)
        {
            return UserInfoDal.EditUserInfo(userInfo) > 0;
        }
        /// <summary>
        /// 计算获取数据的范围，完成分页
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <returns></returns>
        public List<UserInfo> GetPageList(int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageSize * pageIndex;
            return UserInfoDal.GetPageList(start,end);
        }
        /// <summary>
        /// 获取总的页数
        /// </summary>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = UserInfoDal.GetRecordCount();//获取总的记录数
            int pageCount = Convert.ToInt32( Math.Ceiling( (double)recordCount / pageSize));
            return pageCount;
        }
    }
}
