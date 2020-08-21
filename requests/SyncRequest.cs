using System.Net.Http;
using Storage;
using System;
using Extentions;
using System.Threading.Tasks;

namespace web3
{
    public class SyncRequest : IHttpRequest
    {
        private Response response;

        async Task<Response> IHttpRequest.Perform()
        {
            response = new Response();
            foreach (var page in DataStorage.tags)
            {
                Console.WriteLine($"URL = {DataStorage.urls.GetRandomElement() + page}")   ;
                await response.ParseHttpResponseAsync(await new HttpClient().GetAsync(DataStorage.urls.GetRandomElement() + page));
            }
            return response;
        }
    }
}