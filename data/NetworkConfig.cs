using System.Collections.Generic;

namespace web3
{
    public class NetworkConfig
    {
        private static NetworkConfig _instance;
        public static string[] endpoints = { "who", "how", "does", "what" };
        
        private string[] urls;

        public string[] GetUrls() => urls;

        public void SetUrls(string hostname, int count)
        {
            urls = new string[count];
            for (int i = 0; i < urls.Length;)
            {
                urls[i] = $"http://{hostname}{++i}";
            }
        }
    }
}