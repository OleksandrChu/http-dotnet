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
            var response = request.Perform().Result;
            await context.Response.WriteAsync($"{response.GetQuote()}\n{response.GetInfo()}");
        }
    }
}