using System.Net.Http;
using Storage;
using System;
using Extentions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace web3
{
    public class SyncRequest : IHttpRequest
    {

        public async Task<Response> Perform(IEnumerable<Task<HttpResponseMessage>> requests)
        {
            var response = new Response();
            foreach (var task in requests)
            {
                await response.ParseHttpResponseAsync(httpResponseMessage: (await task));
            }
            return response;
        }
    }
}