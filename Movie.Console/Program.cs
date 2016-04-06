using System.Threading.Tasks;
using static Movie.Data.MovieMain;

namespace Movie.Console
{
    class Program
    {
        static async Task Demo()
        {
            var info = await GetMovieInfo("Interstellar");
            if (info.HasMovie)
            {
                System.Console.WriteLine(info.Movie.Details.Released);
            }
        }

        static void Main(string[] args)
        {
            var demo = Demo();
            System.Console.WriteLine("downloading...");
            demo.Wait();
        }
    }
}
