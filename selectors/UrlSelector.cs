namespace web3
{
    public class UrlSelector
    {
        private IUrlSelection urlSelection;

        public UrlSelector(IUrlSelection urlSelection)
        {
            this.urlSelection = urlSelection;
        }

        public string[] GenerateUrlsWithEndpoints(string[] urls) {
            var generatedUrls = new string[NetworkConfig.endpoints.Length];
            var selectedUrls = urlSelection.Select(urls);
            for (int i = 0; i < generatedUrls.Length; i++)
            {
                generatedUrls[i] = $"{selectedUrls[i]}/{NetworkConfig.endpoints[i]}";
            }
            return generatedUrls;
        }
    }
}