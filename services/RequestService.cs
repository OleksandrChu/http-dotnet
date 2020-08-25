using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Storage;
using Extentions;
using web33;

namespace web3
{
    public class RequestService
    {
        private IHttpRequest request;
        private IUrlSelection urlSelection;
        private HttpContext context;
        
        public RequestService(IHttpRequest request, IUrlSelection urlSelection, HttpContext context)
        {
            this.request = request;
            this.urlSelection = urlSelection;
            this.context = context;
        }

        public async Task PerformRequest(string[] urls)
        {
            var requests = new UrlSelector(urlSelection)
            .GenerateUrlsWithEndpoints(urls)
            .Select(url => RequestTask(url));
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = request.Perform(requests).Result;
            stopWatch.Stop();
            await context.Response.WriteAsync($"Execution time: {stopWatch.ElapsedMilliseconds}\n{response.GetQuote()}\n{response.GetInfo()}");
        }

        private async Task<HttpResponseMessage> RequestTask(string url)
        {   
            System.Console.WriteLine("URLLLLLLLLLLLLLLLLL  =====> " + url);
            return await new HttpClient().GetAsync(url);
        }
    }
}