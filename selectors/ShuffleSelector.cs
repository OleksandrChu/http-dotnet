using FisherYatesShuffle;

namespace web33
{
    public class ShuffleSelector : IUrlSelection
    {
        public string[] Select(string[] urls)
        {
            // urls.OrderBy(element => random.Next()).ToArray();
            return urls.Shuffle();
        }
    }
}