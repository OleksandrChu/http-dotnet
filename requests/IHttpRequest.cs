using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace web3
{
    public interface IHttpRequest
    {
        Task<Response> Perform(IEnumerable<Task<HttpResponseMessage>> requests);
    }
}