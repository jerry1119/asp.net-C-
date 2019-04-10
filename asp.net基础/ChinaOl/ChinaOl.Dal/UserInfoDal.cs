using ChinaOl.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ChinaOl.Dal
{
    public class UserInfoDal
    {
        //获取用户列表
        public List<UserInfo> GetList()
        {
            string sql = "select UserId, UserName, DelFlag, UserPwd, Email, RegTime from UserInfo";
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text);
            List<UserInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo userinfo = null;
                foreach (DataRow row in dt.Rows)
                {
                    userinfo = new UserInfo();
                    LoadEntity(userinfo, row);
                    list.Add(userinfo);
                }
            }
            return list;
        }
        //添加用户信息
        public int AddUserInfo(UserInfo userInfo)
        {
            string sql = "insert into UserInfo(UserName,UserPwd,Email,RegTime) values(@UserName,@UserPwd,@Email,@RegTime)";
            SqlParameter[] pars = {
                new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                new SqlParameter("@UserPwd",SqlDbType.NVarChar,32),
                new SqlParameter("@Email",SqlDbType.NVarChar,32),
                new SqlParameter("@RegTime",SqlDbType.DateTime)
            };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPwd;
            pars[2].Value = userInfo.Email;
            pars[3].Value = userInfo.RegTime;
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pars);
        }
        //根据id获取用户的信息
        public UserInfo GetUserInfo(int id)
        {
            string sql = "select UserId, UserName, DelFlag, UserPwd, Email, RegTime from UserInfo where UserId = @ID";
            SqlParameter[] pars = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            pars[0].Value = id;
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text, pars);
            UserInfo userinfo = null;
            if (dt.Rows.Count > 0)
            {
                userinfo = new UserInfo();
                LoadEntity(userinfo, dt.Rows[0]);
            }
            return userinfo;
        }
        //根据用户名获取用户的信息
        public UserInfo GetUserInfo(string userName)
        {
            string sql = "select UserId, UserName, DelFlag, UserPwd, Email, RegTime from UserInfo where UserName   = @UserName";
            SqlParameter[] pars = {
                new SqlParameter("@UserName",SqlDbType.NChar,32)
            };
            pars[0].Value = userName;
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text, pars);
            UserInfo userinfo = null;
            if (dt.Rows.Count > 0)
            {
                userinfo = new UserInfo();
                LoadEntity(userinfo, dt.Rows[0]);
            }
            return userinfo;
        }
        //根据id删除用户的信息
        public int DeleteUserInfo(int id)
        {
            string sql = "delete from UserInfo where UserId = @ID";
            
            SqlParameter[] pars = {
                new SqlParameter("@ID",SqlDbType.Int)
            };
            pars[0].Value = id;
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pars);
        }
        //修改用户信息
        public int EditUserInfo(UserInfo userInfo)
        {
            string sql = "update UserInfo set UserName=@UserName,UserPwd=@UserPwd,Email=@Email,RegTime=@RegTime where UserId=@ID";
            SqlParameter[] pars = {
                new SqlParameter("@UserName",SqlDbType.NVarChar,32),
                new SqlParameter("@UserPwd",SqlDbType.NVarChar,32),
                new SqlParameter("@Email",SqlDbType.NVarChar,32),
                new SqlParameter("@RegTime",SqlDbType.DateTime),
                new SqlParameter("@ID",SqlDbType.Int)
            };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPwd;
            pars[2].Value = userInfo.Email;
            pars[3].Value = userInfo.RegTime;
            pars[4].Value = userInfo.UserId;
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pars);
        }
        /// <summary>
        /// 根据指定的范围，获取指定的数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<UserInfo> GetPageList(int start,int end)
        {
            string sql = "select * from(select *,row_number()over(order by UserId) as num from UserInfo) as t where t.num>=@start and t.num<=@end";
            SqlParameter[] pars =  {
                new SqlParameter("@start",SqlDbType.Int),
                new SqlParameter("@end",SqlDbType.Int)
            };
            pars[0].Value = start;
            pars[1].Value = end;
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text, pars);
            List<UserInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo userinfo = null;
                foreach (DataRow row in dt.Rows)
                {
                    userinfo = new UserInfo();
                    LoadEntity(userinfo, row);
                    list.Add(userinfo);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取总的记录数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(*) from UserInfo";
            return Convert.ToInt32( SqlHelper.ExcuteScalar(sql,CommandType.Text));
        }
        private void LoadEntity(UserInfo userinfo, DataRow row)
        {
            userinfo.UserId = Convert.ToInt32(row["UserId"]);
            userinfo.UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            userinfo.UserPwd = row["UserPwd"] != DBNull.Value ? row["UserPwd"].ToString() : string.Empty;
            userinfo.Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : string.Empty;
            userinfo.RegTime = row["RegTime"] != DBNull.Value ? Convert.ToDateTime(row["RegTime"]) : DateTime.Now;
        }
    }
}
