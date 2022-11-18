using TMDbLib.Client;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace asyncenumerableyield_console
{
    public class MovieCollectionService
    {
        private readonly TMDbClient _client;

        public MovieCollectionService()
        {
            var apiKey = GetApiKey();
            _client = new TMDbClient(apiKey);
        }

        public async IAsyncEnumerable<SearchTv> GetTVShowsIAsyncEnumerable()
        {
            var selectedLang = "en";

            var page = 1;
            do
            {
                var shows = await _client.GetTvShowListAsync(TvShowListType.Popular, selectedLang, page);
                await Task.Delay(1000);

                var searchResults = shows.Results.Take(1);
                foreach (var show in searchResults)
                {
                    yield return show;
                }

                page++;

            } while (page <= 10);
        }

        public async Task<IEnumerable<SearchTv>> GetTVShowsIEnumerable()
        {
            var selectedLang = "en";
            var searchResults = new List<SearchTv>();

            var page = 1;
            do
            {
                var shows = await _client.GetTvShowListAsync(TvShowListType.Popular, selectedLang, page);
                await Task.Delay(1000);
                searchResults.AddRange(shows.Results.Take(1));
                page++;


            } while (searchResults.Count < 10);

            return searchResults;
        }

        public IEnumerable<SearchTv> GetTVShows()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                yield return new SearchTv() {  Name = "Movie Name : " + i};
            }
        }

        private static string GetApiKey()
        {
            return "e4a9881a9a3e0972af357b42c39afb04";

        }
    }
}
