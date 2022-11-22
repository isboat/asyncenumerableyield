namespace asyncenumerableyield_console
{
    /* Async Stream
     * IAsyncEnumerable with Yield
     */
    public class Program
    {
        static async Task Main(string[] args)
        {
            /*
             * Retrieve shows from the movie database - TMDb
             * 
             */
            var _movieCollectionService = new MovieCollectionService();


            Console.WriteLine($" ----------    Using Task<IEnumerable<T>>");
            foreach (var show in await _movieCollectionService.GetTVShowsIEnumerable())
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Show name: {show.Name}");
            }


            Console.WriteLine($" ----------    Using IEnumerable<T>");
            foreach (var show in _movieCollectionService.GetTVShows())
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Show name: {show.Name}");
            }



            Console.WriteLine($" ----------    IAsyncEnumerable with Yield");
            await foreach (var show in _movieCollectionService.GetTVShowsIAsyncEnumerable())
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Show name: {show.Name}");
            }
        }
    }
}