using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Storage;
using Extentions;

namespace web3
{
    public class RequestService
    {
        private IHttpRequest request;
        private HttpContext context;

        public RequestService(IHttpRequest request, HttpContext context)
        {
            this.request = request;
            this.context = context;
        }

        public async Task PerformRequest()
        {
            var requests = DataStorage.pages.Select(page => RequestTask(page));
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = request.Perform(requests).Result;
            stopWatch.Stop();
            await context.Response.WriteAsync($"Execution time: {stopWatch.ElapsedMilliseconds}\n{response.GetQuote()}\n{response.GetInfo()}");
        }

        private async Task<HttpResponseMessage> RequestTask(string page)
        {
            return await new HttpClient().GetAsync(DataStorage.urls.GetRandomElement() + page);
        }
    }
}