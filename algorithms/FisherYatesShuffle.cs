using System;

namespace FisherYatesShuffle
{
    public static class FisherYatesShuffle
    {
        public static string[] Shuffle(this string[] urls)
        {
            Random random = new Random();
            for (int i = 0; i < urls.Length; i++)
            {
                string currentUrl = urls[i];
                int index = random.Next(i, urls.Length);
                urls[i] = urls[index];
                urls[index] = currentUrl;
            }
            return urls;
        }
    }
}