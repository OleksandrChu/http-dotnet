using Storage;
using Extentions;
using System.Linq;
using System;

namespace web33
{
    public class RandomSelector : IUrlSelection
    {
        public string[] Select(string[] urls)
        {
            var randomUrls = new string[urls.Length];
            for (int i = 0; i < DataStorage.endpoints.Length; i++)
            {
                randomUrls[i] = urls.GetRandomElement();
            }
            return randomUrls;
        }
    }
}