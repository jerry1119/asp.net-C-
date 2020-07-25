using System;
using System.Web.Mvc;
using RentHouse.IService;
using ServiceStack.Redis;

namespace RentHouse
{
    public class RedisHelper
    {
        private static PooledRedisClientManager redisMgr;
        static RedisHelper()
        {
            var settingServer = DependencyResolver.Current.GetService<ISettingService>();
            var redisServer = settingServer.GetValue("RedisServers").Split(';')[0];
            redisMgr = new PooledRedisClientManager(redisServer);
        }
        public static void SetValue<T>(string key, T value,TimeSpan expireSpan)
        {
            using (IRedisClient redisClient = redisMgr.GetClient())
            { 
                redisClient.Set(key, value,expireSpan);
            }
        }
        public static T GetValue<T>(string key)
        {
            using (IRedisClient redisClient = redisMgr.GetClient())
            {
               return redisClient.Get<T>(key);
            }
        }
    }
}