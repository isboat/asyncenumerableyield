using TMDbLib.Client;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace asyncenumerableyield_api
{
    public class MovieCollectionService: IMovieCollectionService
    {
        private readonly TMDbClient _client;

        public MovieCollectionService()
        {
            var apiKey = GetApiKey();
            _client = new TMDbClient(apiKey);
        }

        public async IAsyncEnumerable<SearchTv> GetTVShows()
        {
            var selectedLang = "en";
            var searchResults = new List<SearchTv>();

            var page = 1;
            do
            {
                var shows = await _client.GetTvShowListAsync(TvShowListType.Popular, selectedLang, page);
                searchResults.AddRange(shows.Results.Take(4));
                page++;

                foreach (var show in searchResults)
                {
                    yield return show;
                }

            } while (searchResults.Count < 11);

            Console.WriteLine();
        }

        private static string GetApiKey()
        {
            return "e4a9881a9a3e0972af357b42c39afb04";

        }
    }
    public interface IMovieCollectionService
    {
        IAsyncEnumerable<SearchTv> GetTVShows();
    }
}
