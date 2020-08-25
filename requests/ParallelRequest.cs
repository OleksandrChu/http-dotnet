using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Storage;
using Extentions;
using System.Collections;
using System.Collections.Generic;

namespace web3
{
    public class ParallelRequest : IHttpRequest
    {
        public async Task<Response> Perform(IEnumerable<Task<HttpResponseMessage>> requests)
        {
            var response = new Response();
            await Task.WhenAll(requests).ContinueWith(async tasks =>
            {
                foreach (var task in tasks.Result)
                {
                    await response.ParseHttpResponseAsync(task);
                }
            });
            return response;
        }
    }
}