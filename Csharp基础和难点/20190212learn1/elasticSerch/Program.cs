using System;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace elasticSerch
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var settings = new ConnectionConfiguration(new Uri("http://localhost:9200")).RequestTimeout(TimeSpan.FromMinutes(2));
            var lowlevelClient = new ElasticLowLevelClient(settings);
            var person = new 
            {
                FirstName = "liu",
                LastName = "jie",
                Age = "18"
            };
            //var indexResponse = lowlevelClient.Index<BytesResponse>("people", "1", PostData.Serializable(person));
            //byte[] responseBytes = indexResponse.Body;

            //异步的方式
            //var asyncIndexResponse = await lowlevelClient.IndexAsync<StringResponse>("people", "2", PostData.Serializable(person));
            //string responseString = asyncIndexResponse.Body;
            //Console.WriteLine(responseString);
            //Console.ReadKey();

            //search 搜索 
            var searchResponse = lowlevelClient.Search<StringResponse>("people", PostData.Serializable(new
            {
                from = 0,
                size = 10,
                query  = new
                {
                    match = new
                    {
                        firstName = new
                        {
                            query = "li"
                        }
                    }
                }
            }));

            var successful = searchResponse.Success;
            var responseJson = searchResponse.Body;
            Console.WriteLine(successful);
            Console.WriteLine(responseJson);
            Console.ReadKey();
        }
    }
}
