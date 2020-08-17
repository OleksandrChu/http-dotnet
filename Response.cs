using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace web3
{
    public class Response
    {
        private string info;
        private string quote;
        private string stream;

        internal async Task ParseHttpResponseAsync(HttpResponseMessage httpResponseMessage)
        {
            stream = await httpResponseMessage.Content.ReadAsStringAsync() + " ";
            quote += stream;
            info += $"{httpResponseMessage.Headers.GetValues("InCamp-Student").First()} send: {stream} \n";
        }

        public string GetQuote()
        {
            return quote;
        }

        public string GetInfo()
        {
            return info;
        }
    }
}