using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Storage;
using Extentions;

namespace web3
{
    public class ParallelRequest : IHttpRequest
    {
        public async Task<Response> Perform()
        {
            var response = new Response();
            var requests = DataStorage.tags.Select(tag => RequestTask(response, tag));
            await Task.WhenAll(requests).ContinueWith(async tasks =>
            {
                foreach (var task in tasks.Result)
                {
                    await response.ParseHttpResponseAsync(task);
                }
            });
            return response;
        }

        private async Task<HttpResponseMessage> RequestTask(Response response, string tag)
        {
            return await new HttpClient().GetAsync(DataStorage.urls.GetRandomElement() + tag);
        }
    }
}