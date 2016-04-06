using Movie.Data;

namespace Movie.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = MovieMain.GetMovieInfo("Superman");
            if (info.HasMovie)
            {
                System.Console.WriteLine(info.Movie.Details.Released);
            }
        }
    }
}
