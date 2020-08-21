using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

        public async Task PerformRequestAsync()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = request.Perform().Result;
            stopWatch.Stop();
            await context.Response.WriteAsync($"Execution time: {stopWatch.ElapsedMilliseconds}\n{response.GetQuote()}\n{response.GetInfo()}");
        }
    }
}