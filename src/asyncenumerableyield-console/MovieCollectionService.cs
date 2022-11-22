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
            var page = 1;
            do
            {
                var shows = await _client.GetTvShowListAsync(TvShowListType.Popular, "en", page);
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
            var searchResults = new List<SearchTv>();

            var page = 1;
            do
            {
                var shows = await _client.GetTvShowListAsync(TvShowListType.Popular, "en", page);
                
                // Simulate a 1 sec
                await Task.Delay(1000);
                
                searchResults.AddRange(shows.Results.Take(1));
                page++;


            } while (page <= 10);

            return searchResults;
        }

        public IEnumerable<SearchTv> GetTVShows()
        {

            var page = 1;

            do
            {
                var shows = _client.GetTvShowListAsync(TvShowListType.Popular, "en", page).Result;
                IEnumerable<SearchTv> searchResults = shows.Results.Take(1);

                Thread.Sleep(1000);

                foreach (var show in searchResults)
                {
                    yield return show;
                }

                page++;


            } while (page <= 10);
        }

        private static string GetApiKey()
        {
            return "7c254b68062cdaff22c742219ae8f647";

        }
    }
}
