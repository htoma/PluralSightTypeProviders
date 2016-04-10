using System.Threading.Tasks;
using System.Web.Mvc;
using static Movie.Data.MovieMain;


namespace Movies.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var movies = await GetLatestMovies();
            return View(movies);
        }

        public async Task<ActionResult> Details(string title)
        {
            var details = await GetMovieInfo(title);
            if (details.HasMovie)
            {
                return View(details.Movie);
            }
            return View("MovieNotFound");
        }
    }
}