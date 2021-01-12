using System;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace RentHouse.Web.Common
{
    public class ESearchHelper
    {
        private static ElasticLowLevelClient _lowlevelClient;
        public ESearchHelper()
        {
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200")).RequestTimeout(TimeSpan.FromMinutes(1));
            _lowlevelClient = new ElasticLowLevelClient(settings);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">index的名字类似数据库名或者表名?</param>
        /// <param name="id">id</param>
        /// <param name="document">相当于一个对象</param>
        /// <returns></returns>
        public static async Task<bool> IndexAsync(string index, string id, object document)
        {
            var syncIndexResponse =
                await _lowlevelClient.IndexAsync<StringResponse>(index, id, PostData.Serializable(document));
            
            return syncIndexResponse.Success;
        }

        public static string Search(string index, object option)
        {
            var searchResponse = _lowlevelClient.Search<StringResponse>(PostData.Serializable(option));
            string responseJson = searchResponse.Body;
            return responseJson;
        }
    }
}