using web33;
using Extentions;
using System.Linq;
using System;

namespace web3
{
    public class RandomSelector : IUrlSelection
    {
        public string[] Select(string[] urls)
        {
            var randomUrls = new string[urls.Length];
            for (int i = 0; i < NetworkConfig.endpoints.Length; i++)
            {
                randomUrls[i] = urls.GetRandomElement();
            }
            return randomUrls;
        }
    }
}