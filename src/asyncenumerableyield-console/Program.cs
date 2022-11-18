namespace asyncenumerableyield_console
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello world");


            var _movieCollectionService = new MovieCollectionService();



            var col = _movieCollectionService.GetTVShows();
            Console.WriteLine($"Synchronous: Total retrieved: {col.Count()}");
            foreach (var show in col)
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Show name: {show.Name}");
            }



            var col2 = await _movieCollectionService.GetTVShowsIEnumerable();
            Console.WriteLine($"Async: Total retrieved: {col.Count()}");
            foreach (var show in col2)
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Show name: {show.Name}");
            }

            Console.WriteLine($"IAsyncEnumerable with Yield");
            await foreach (var show in _movieCollectionService.GetTVShowsIAsyncEnumerable())
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} Show name: {show.Name}");
            }
        }
    }
}