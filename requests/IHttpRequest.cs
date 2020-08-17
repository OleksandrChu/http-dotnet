using System.Threading.Tasks;

namespace web3
{
    public interface IHttpRequest
    {
        Task<Response> Perform();
    }
}