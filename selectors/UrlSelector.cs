using Storage;

namespace web33
{
    public class UrlSelector
    {
        private IUrlSelection urlSelection;

        public UrlSelector(IUrlSelection urlSelection)
        {
            this.urlSelection = urlSelection;
        }

        public string[] GenerateUrlsWithEndpoints(string[] urls) {
            var generated = new string[DataStorage.endpoints.Length];
            var selectedUrls = urlSelection.Select(urls);
            for (int i = 0; i < generated.Length; i++)
            {
                generated[i] = $"{selectedUrls[i]}/{DataStorage.endpoints[i]}";
            }
            return generated;
        }
    }
}