using FisherYatesShuffle;

namespace web3
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